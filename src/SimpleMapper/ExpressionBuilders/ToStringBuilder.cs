using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class ToStringBuilder : ExpressionBuilder
    {
        protected override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            var toStringMethod = inputType.GetMethod("ToString", new[] { typeof(IFormatProvider) });
            // using ToString with IFormatProvider if any
            var toString = toStringMethod != null
                ? Expression.Call(input, toStringMethod, Expression.Constant(config.FormatProvider))
                : Expression.Call(input, "ToString", null, null);
            return inputType.IsNullable()
                       ? input.TernaryNullCheck(targetType.Default(), toString)
                       : toString;
        }
    }
}