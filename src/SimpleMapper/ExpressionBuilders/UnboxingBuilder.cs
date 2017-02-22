using System;
using System.Linq.Expressions;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class UnboxingBuilder : ExpressionBuilder
    {
        protected override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            return targetType.IsNullable() ? 
                input.SafeUnboxing(targetType.StripNullable()).ExplicitTo(targetType) : 
                input.SafeUnboxing(targetType.StripNullable());
        }
    }
}