using System;
using System.Linq.Expressions;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class GenericListToArrayBuilder : ExpressionBuilder
    {
        protected override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            var inputElementTypes = inputType.GetGenericArguments();
            if (inputElementTypes.Length != 1)
            {
                throw new NotSupportedException(string.Format("Wrong generic arguments count. 1 expected, {0} found",
                    inputElementTypes.Length));
            }
            var outputRank = targetType.GetArrayRank();
            if (outputRank != 1) { throw new NotSupportedException("Mapping from List to multidimensional array is not supported"); }
            var targetElementType = targetType.GetElementType();

            var i = Expression.Variable(typeof(int), string.Format("i{0}", config.CurrentDepthLevel));
            var arr = Expression.Variable(targetType, string.Format("arr{0}", config.CurrentDepthLevel));
            // arrLength = inputArray.Length
            var arrLength = Expression.Property(input, "Count");
            // arr = new targetType[arrLength]
            var arrAssign = arr.Assign(Expression.NewArrayBounds(targetElementType, arrLength));
            var assignLoopVariable = i.Assign(0.Constant());
            var breakLabel = Expression.Label(targetType);
            // arr[i] = MapperFactory.CreateExpression<inputElementType, targetElementType>(inputArray[i])
            var assignValue = arr.Access(i).Assign(MapperFactory.CreateExpression(input.IndexerAccess(i),
                inputElementTypes[0], targetElementType, config.NextDepthLevel()));
            // i++
            var increment = Expression.PostIncrementAssign(i);
            var gotoBreak = Expression.Goto(breakLabel, arr);
            // if (i >= arrLength) break
            var checkArrayBounds = Expression.IfThen(Expression.GreaterThanOrEqual(i, arrLength), gotoBreak);
            var loopBody = Expression.Block(checkArrayBounds, assignValue, increment);
            var loop = Expression.Loop(loopBody, breakLabel);
            // int i = 0; {  while (true) { if (i>=inputArray.Length) goto break; { arr[i] = converter(inputArray[i]); i++; } } }
            var loopBlock = Expression.Block(new[] { i }, assignLoopVariable, loop);
            return input.TernaryNullCheck(targetType.Default(), Expression.Block(new[] { arr }, arrAssign, loopBlock));
        }
    }
}