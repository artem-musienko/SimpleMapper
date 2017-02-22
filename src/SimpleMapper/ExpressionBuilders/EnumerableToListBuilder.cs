using System;
using System.Linq;
using System.Linq.Expressions;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class EnumerableToListBuilder : ExpressionBuilder
    {
        protected override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            var inputElementTypes = inputType.GetGenericArguments();
            if (inputElementTypes.Count() != 1)
            {
                throw new NotSupportedException(string.Format("Wrong generic arguments count. 1 expected, {0} found",
                    inputElementTypes.Length));
            }
            var inputElementType = inputElementTypes[0];
            var outputElementTypes = targetType.GetGenericArguments();
            if (outputElementTypes.Count() != 1)
            {
                throw new NotSupportedException(string.Format("Wrong generic arguments count. 1 expected, {0} found",
                    outputElementTypes.Length));
            }
            var outputElementType = outputElementTypes[0];
            var param = Expression.Parameter(inputElementType, "@in");
            Expression func =
                Expression.Lambda(MapperFactory.CreateExpression(param, inputElementType, outputElementType, config.NextDepthLevel()), param);
            var result = Expression.Call(typeof(Enumerable), "Select", new[] { inputElementType, outputElementType }, input, func);
            var toList = Expression.Call(typeof(Enumerable), "ToList", new[] { outputElementType }, result);
            return input.TernaryNullCheck(targetType.Default(), toList);
        }
    }
}