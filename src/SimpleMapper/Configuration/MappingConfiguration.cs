using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleMapper.Configuration
{

    /// <summary>
    /// Mapper configuration
    /// </summary>
    public sealed partial class MappingConfiguration<TIn, TOut>
    {
        public MappingConfiguration()
        {
            _value = new Lazy<string>(CalculateValue);
        }

        private readonly List<string> _ignoreProperties = new List<string>();
        private readonly Dictionary<string, object> _customTypeConverters = new Dictionary<string, object>();
        private readonly Dictionary<string, object> _aggregateFuncs = new Dictionary<string, object>();
        private readonly Dictionary<string, Delegate> _forProperties = new Dictionary<string, Delegate>();

        /// <summary>
        /// Ignore specified property of the target type
        /// </summary>
        /// <typeparam name="TProperty">Property type</typeparam>
        /// <param name="property">Property to ignore</param>
        /// <returns></returns>
        public MappingConfiguration<TIn, TOut> Ignore<TProperty>(Expression<Func<TOut, TProperty>> property)
        {
            ResetValue();
            var str = ParseExpressionAsPropertyAccess(property.Body);
            _ignoreProperties.Add(str);
            return this;
        }

        /// <summary>
        /// Use custom type converter for specified types
        /// </summary>
        /// <typeparam name="TFrom">Input type</typeparam>
        /// <typeparam name="TTo">Output type</typeparam>
        /// <param name="customConverter">Custom delegate used for type conversion</param>
        /// <returns></returns>
        public MappingConfiguration<TIn, TOut> ForTypes<TFrom, TTo>(Func<TFrom, TTo> customConverter)
        {
            ResetValue();
            var key = $"{typeof(TFrom).FullName} - {typeof(TTo).FullName}";
            if (_customTypeConverters.ContainsKey(key))
            {
                _customTypeConverters[key] = customConverter;
            }
            else
            {
                _customTypeConverters.Add(key, customConverter);
            }
            return this;
        }

        /// <summary>
        /// Use custom type converter for specified types when converting specified property of any instance of TClass
        /// </summary>
        /// <typeparam name="TProperty">Property type</typeparam>
        /// <param name="forProperty">Property of the target type</param>
        /// <param name="useConverter">Converter for custom mapping</param>
        /// <returns></returns>
        public MappingConfiguration<TIn, TOut> ForProperty<TProperty>(Expression<Func<TOut, TProperty>> forProperty, Func<TIn, TProperty> useConverter)
        {
            ResetValue();
            var str = ParseExpressionAsPropertyAccess(forProperty.Body);
            if (_customTypeConverters.ContainsKey(str))
            {
                _forProperties[str] = useConverter;
            }
            else
            {
                _forProperties.Add(str, useConverter);
            }
            return this;
        }

        /// <summary>
        /// Aggregate property of the target object from the source object
        /// </summary>
        /// <typeparam name="TProperty">Property type</typeparam>
        /// <param name="property">Property selector</param>
        /// <param name="aggregate">Aggregate delegate</param>
        /// <returns></returns>
        public MappingConfiguration<TIn, TOut> AggregateProperty<TProperty>(Expression<Func<TOut, TProperty>> property, Func<TIn, TProperty> aggregate)
        {
            ResetValue();
            var key = ParseExpressionAsPropertyAccess(property.Body);
            if (_customTypeConverters.ContainsKey(key))
            {
                _aggregateFuncs[key] = aggregate;
            }
            else
            {
                _aggregateFuncs.Add(key, aggregate);
            }
            return this;
        }

        public MappingConfiguration<TIn, TOut> Using<T, T1>(MappingConfiguration<T, T1> customConverter)
        {
            return this;
        }

        #region private methods

        private static IEnumerable<T> Reverse<T>(IList<T> items)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        private static string ParseExpressionAsPropertyAccess(Expression property, List<string> properties = null)
        {
            var me = property as MemberExpression;
            if (me == null) { throw new NotSupportedException("Unable to parse expression as MemberExpression"); }
            var pi = me.Member as PropertyInfo;
            if (pi == null) { throw new NotSupportedException("Provided expression refers a field, not a property"); }

            if (me.Expression is MemberExpression)
            {
                if (properties == null)
                {
                    properties = new List<string>();
                }
                properties.Add(pi.Name);
                return ParseExpressionAsPropertyAccess(me.Expression, properties);
            }
            if (properties == null)
            {
                return pi.Name;
            }
            properties.Add(pi.Name);
            return string.Join(".", Reverse(properties));
        }

        #endregion

        #region equality

        // ReSharper disable StaticFieldInGenericType 
        // unique identifier for each generic class
        private static readonly int hashCode = typeof(TIn).GetHashCode() + typeof(TOut).GetHashCode();
        // ReSharper restore StaticFieldInGenericType

        public override int GetHashCode()
        {
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var config = obj as MappingConfiguration<TIn, TOut>;
            return config != null && config.Value == Value;
        }

        private Lazy<string> _value;

        private void ResetValue()
        {
            if (_value.IsValueCreated)
            {
                _value = new Lazy<string>(CalculateValue);
            }
        }

        public string Value
        {
            get
            {
                return _value.Value;
            }
        }

        private string CalculateValue()
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{{");
            builder.AppendFormat("from:'{0}', to:'{1}'", typeof(TIn).FullName, typeof(TOut).FullName);
            if (_ignoreProperties.Count > 0)
            {
                builder.AppendFormat(", ignore:'{0}'", string.Join(", ", _ignoreProperties.Distinct().OrderBy(s => s)));
            }
            if (_forProperties.Count > 0)
            {
                builder.AppendFormat(", forTypes:'{0}'", string.Join(", ",
                    _forProperties
                    .Select(kvp => string.Format("{0} - {1}", kvp.Key, RuntimeHelpers.GetHashCode(kvp.Value)))
                    .OrderBy(s => s)));
            }
            if (_aggregateFuncs.Count > 0)
            {
                builder.AppendFormat(", aggregates:'{0}'", string.Join(", ",
                    _aggregateFuncs
                    .Select(kvp =>
                    {
                        var @delegate = kvp.Value as Delegate;
                        return @delegate != null ? string.Format("{0} - {1}", kvp.Key, @delegate.Method) : null;
                    })
                    .OrderBy(s => s)));
            }
            builder.AppendFormat("}}");
            return builder.ToString();
        }

        #endregion

    }
}