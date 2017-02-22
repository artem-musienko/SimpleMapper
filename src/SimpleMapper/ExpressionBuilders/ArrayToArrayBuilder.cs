using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class ArrayToArrayBuilder : ExpressionBuilder
    {
        private Expression MultiDimensional(int rank, Expression input, Type inputType, Type targetType,
                                            InternalMapperConfig config)
        {
            var inputElementType = inputType.GetElementType();
            var targetElementType = targetType.GetElementType();

            var loopVariables = rank.CreateArray(i => Expression.Variable(typeof(int), string.Format("loop{0}", i)));
            var arr = Expression.Variable(targetType, "arr");

            var dimensions = rank.CreateArray(i => Expression.Variable(typeof(int), string.Format("length{0}", i)));
            var dimensionsAssign = rank.CreateArray(i => (Expression)Expression.Call(input,
                    typeof(Array).GetMethod("GetLength", BindingFlags.Public | BindingFlags.Instance),
                    Expression.Constant(i)))
                    .ForEach((expression, i) => dimensions[i].Assign(expression));
            var arrAssign = arr.Assign(Expression.NewArrayBounds(targetElementType, dimensions));
            var zeroLoopVariables = rank.CreateArray(i => loopVariables[i].Assign(0.Constant()));
            var breakLabels = rank.CreateArray(i => Expression.Label(targetType, string.Format("loop{0}", i)));
            var assignValue =
                arr.Access(loopVariables)
                   .Assign(MapperFactory.CreateExpression(input.Index(loopVariables), inputElementType, targetElementType, config.NextDepthLevel()));
            var increments = rank.CreateArray(i => Expression.PostIncrementAssign(loopVariables[i]));
            var gotoBreaks = rank.CreateArray(i => Expression.Goto(breakLabels[i], arr));
            var checkArrayBounds = rank.CreateArray(i => Expression.IfThen(Expression.GreaterThanOrEqual(loopVariables[i], dimensions[i]), gotoBreaks[i]));

            // nesting loops
            var loopBody = assignValue;
            for (int i = rank - 1; i >= 0; i--)
            {
                loopBody = Expression.Block(checkArrayBounds[i], loopBody, increments[i]);
                loopBody = Expression.Loop(loopBody, breakLabels[i]);
                loopBody = Expression.Block(zeroLoopVariables[i], loopBody);
            }
            var loopsBlock = Expression.Block(loopVariables, loopBody);
            return input.TernaryNullCheck(targetType.Default(), 
                Expression.Block(dimensions.Union(arr), dimensions.Union(dimensionsAssign).Union(arrAssign).Union(loopsBlock)));
        }

        private Expression OneDimensional(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            var inputElementType = inputType.GetElementType();
            var targetElementType = targetType.GetElementType();

            var i = Expression.Variable(typeof(int), string.Format("i{0}", config.CurrentDepthLevel));
            var arr = Expression.Variable(targetType, string.Format("arr{0}", config.CurrentDepthLevel));
            // arrLength = inputArray.Length
            var arrLength = Expression.ArrayLength(input);
            // arr = new targetType[arrLength]
            var arrAssign = arr.Assign(Expression.NewArrayBounds(targetElementType, arrLength));
            var assignLoopVariable = i.Assign(0.Constant());
            var breakLabel = Expression.Label(targetType);
            // arr[i] = MapperFactory.CreateExpression<inputElementType, targetElementType>(inputArray[i])
            var assignValue = arr.Access(i).Assign(MapperFactory.CreateExpression(input.Index(i), 
                inputElementType, targetElementType, config.NextDepthLevel()));
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

        protected override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            var inputRank = inputType.GetArrayRank();
            var targetRank = inputType.GetArrayRank();

            if (inputRank != targetRank) { throw new NotSupportedException("Mapping of arrays of different ranks is not supported"); }
            return inputRank == 1
                          ? OneDimensional(input, inputType, targetType, config)
                          : MultiDimensional(inputRank, input, inputType, targetType, config);
        }

    }
}