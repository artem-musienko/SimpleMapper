using System;
using System.Linq.Expressions;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class ImplicitBuilder : ExpressionBuilder
    {
        protected override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            // we still need to perform explicit cast for implicit conversion when using expressions
            return inputType.IsNullable()
                       ? input.TernaryNullCheck(targetType.Default(),
                                                input.ExplicitTo(inputType.StripNullable()).ExplicitTo(targetType))
                       : input.ExplicitTo(targetType);
        }
    }
}