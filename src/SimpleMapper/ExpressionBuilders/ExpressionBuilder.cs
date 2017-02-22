using System;
using System.Linq.Expressions;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal abstract class ExpressionBuilder: IExpressionBuilder
    {
        public Expression Build<TIn, TOut>(Expression input, InternalMapperConfig config)
        {
            return Build(input, typeof (TIn), typeof (TOut), config);
        }

        public virtual bool UsesRecursion { get { return false; } }

        protected abstract Expression Build(Expression input, Type inputType, Type targetType,
                                           InternalMapperConfig config);
    }

    internal interface IExpressionBuilder
    {
        Expression Build<TIn, TOut>(Expression input, InternalMapperConfig config);
        bool UsesRecursion { get; }
    }
}
