using System;
using System.Linq.Expressions;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class FromStringUsingParseBuilder : ExpressionBuilder
    {
        protected override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            // type has static Parse with IFormatProvider overloading
            var parseMethod = targetType.GetMethod("Parse", new[] { typeof(string), typeof(IFormatProvider) });
            if (parseMethod != null)
            {
                return Expression.Call(parseMethod, input, Expression.Constant(config.FormatProvider));
            }
            // otherwise Parse from string
            parseMethod = targetType.GetMethod("Parse", new[] { typeof(string) });
            return Expression.Call(parseMethod, input);
        }
    }
}