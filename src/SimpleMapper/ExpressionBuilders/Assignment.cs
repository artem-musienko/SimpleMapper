using System;
using System.Linq.Expressions;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class Assignment : ExpressionBuilder
    {
        protected  override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            if (inputType.IsNullable() && targetType.IsNullable()) { return input; }
            if (inputType.IsNullable()) return input.NullCheck(inputType.StripNullable());
            return input;
        }
    }
}