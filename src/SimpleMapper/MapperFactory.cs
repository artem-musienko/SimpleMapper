using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using SimpleMapper.Configuration;
using SimpleMapper.ExpressionBuilders;

namespace SimpleMapper
{

    /// <summary>
    /// Mappers builder
    /// </summary>
    internal static class MapperFactory
    {
        public static Func<Func<TIn, TOut>> Create<TIn, TOut>()
        {
            return Create<TIn, TOut>(config: null);
        }

        /// <summary>
        /// Create and compile new mapper for TIn -> TOut with provided config
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="config"></param>
        /// <returns></returns>
        public static Func<Func<TIn, TOut>> Create<TIn, TOut>(MappingConfiguration<TIn, TOut> config)
        {
            if (MappersCache<TIn, TOut>.IsInit(config))
            {
                return () => MappersCache<TIn, TOut>.Get(config);
            }
            MappersCache<TIn, TOut>.Init(config);
            var param = Expression.Parameter(typeof(TIn), "input");
            var exp = CreateExpression<TIn, TOut>(param, InternalMapperConfig.Init(config));
            var func = Expression.Lambda<Func<TIn, TOut>>(exp, new[] { param });
#if DEBUG
            MapperInfo<TIn, TOut>.Default = new MapperInfo<TIn, TOut>(func);
#endif
            MappersCache<TIn, TOut>.Add(func.Compile(), config);
            return () => MappersCache<TIn, TOut>.Get();
        }

        private static readonly MethodInfo createExpressionMethod =
            typeof(MapperFactory).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .First(mi => mi.Name == "CreateExpression" && mi.IsGenericMethod);

        private static Expression CreateExpression<TIn, TOut>(Expression inputParameter, InternalMapperConfig config)
        {
            var tin = typeof(TIn);
            var tout = typeof(TOut);
            IExpressionBuilder builder;
            if (tin == tout && !tin.IsClass)
            {
                builder = new Assignment();
            }
            else
            {
                var input = GetTypeEnum(tin);
                var output = GetTypeEnum(tout);
                if (input == TypeEnum.Unknown)
                {
                    throw new NotSupportedException(string.Format("Mapping from type '{0}' is not supported", tin));
                }
                if (output == TypeEnum.Unknown)
                {
                    throw new NotSupportedException(string.Format("Mapping from type '{0}' is not supported", tout));
                }
                builder = ExpressionBuildersDictionary.Get(input, output);
                if (builder == null)
                {
                    throw new NotSupportedException(string.Format("Converting from {0} to {1} is not supported", tin.Name, tout.Name));
                }
            }
            var exp = builder.Build<TIn, TOut>(inputParameter, config);
            return exp;
        }

        /// <summary>
        /// Get expression that invokes generic version of factory Create for types pair
        /// </summary>
        /// <param name="inputType"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        internal static Expression GetCreateDelegate(Type inputType, Type targetType)
        {
            return Expression.Call(typeof(MapperFactory), "Create", new[] { inputType, targetType }, null);
        }

        /// <summary>
        /// Invoke generic version of CreateExpression from non-generic context
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputType"></param>
        /// <param name="targetType"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        internal static Expression CreateExpression(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            var i = GetTypeEnum(inputType);
            var o = GetTypeEnum(targetType);
            var builder = ExpressionBuildersDictionary.Get(i, o);
            if (!builder.UsesRecursion)
            {
                // types without recursive calls
                var method = createExpressionMethod.MakeGenericMethod(inputType, targetType);
                return (Expression)method.Invoke(null, new object[] { input, config });
            }
            // for types with recursive use dynamic call of the MapperFactory.Create<inputType, targetType>(config)

            // obtain current mapper delegate
            var exp = Expression.Call(typeof(MapperFactory), "Create", new[] { inputType, targetType }, null);
            return exp
                // get current mapper by calling the delegate
                .InvokeFunc()
                // invoke mapper
                .InvokeFunc(input);
        }

        private static TypeEnum GetTypeEnum(Type type)
        {
            TypeEnum result;
            type = type.StripNullable();
            if (Enum.TryParse(type.Name, out result)) { return result; }
            if (type.IsEnum) { return TypeEnum.Enum; }
            if (type == typeof(NameObjectCollectionBase)
                || type.IsSubclassOf(typeof(NameObjectCollectionBase))) { return TypeEnum.NameValueObjectCollection; }
            if (type.IsArray) { return TypeEnum.Array; }
            if (type == typeof(ArrayList)) { return TypeEnum.ArrayList; }
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>)) { return TypeEnum.GenericList; }
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>)) { return TypeEnum.GenericEnumerable; }
            if (type == typeof(object)) { return TypeEnum.Object; }
            return type.IsClass ? TypeEnum.Class : TypeEnum.Unknown;
        }
    }
}