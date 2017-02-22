using System;
using System.Linq.Expressions;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class BoxingBuilder : ExpressionBuilder
    {
        protected override  Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            return input.ExplicitTo(targetType);
        }
    }
}