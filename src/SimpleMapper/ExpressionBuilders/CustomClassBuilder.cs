using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class CustomClassBuilder : ExpressionBuilder
    {
        private const BindingFlags PROPERTY_FLAGS = BindingFlags.Public | BindingFlags.Instance;

        public override bool UsesRecursion { get { return true; } }

        protected override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            var inputProperties =
                inputType.GetProperties(PROPERTY_FLAGS).Where(p => p.GetGetMethod(false) != null)
                .GroupBy(pi => pi.Name, (s, infos) => infos.OrderByDescending(pi => pi.DeclaringType == inputType).First());
            var outputProperties =
                ApplyIgnores(targetType.GetProperties(PROPERTY_FLAGS).Where(p => p.GetSetMethod(false) != null), targetType, config);

            var matchingPairs = from op in outputProperties
                                join ip in inputProperties on op.Name equals ip.Name into j
                                from p in j.DefaultIfEmpty()
                                select new { From = p, To = op };

            // building object 
            var ctor = Expression.New(targetType);
            // aggregate member bindings
            var bindings = matchingPairs.Select(pair =>
            {
                var custom = GetCustomPropertyConverter(targetType, pair.To, config);
                if (custom == null)
                {
                    if (pair.From == null)
                    {
                        return null;
                    }
                    var converter = MapperFactory.CreateExpression(input.Property(pair.From), pair.From.PropertyType,
                        pair.To.PropertyType, config.NextDepthLevel());
                    return Expression.Bind(pair.To, converter);
                }
                var call = Expression.Invoke(Expression.Constant(custom), input);
                return Expression.Bind(pair.To, call);
            }).Where(b => b != null);
            return input.TernaryNullCheck(targetType.Default(), Expression.MemberInit(ctor, bindings));
        }

        private Delegate GetCustomPropertyConverter(Type targetType, PropertyInfo @to, InternalMapperConfig config)
        {
            if (targetType == null || @to == null)
            {
                return null;
            }
            return config.Custom(targetType, @to.Name);
        }

        private IEnumerable<PropertyInfo> ApplyIgnores(IEnumerable<PropertyInfo> input, Type targetType, InternalMapperConfig config)
        {
            var ignores = config.Ignores(targetType);
            return input.Where(pi => pi.Name.NotIn(ignores));
        }

    }
}