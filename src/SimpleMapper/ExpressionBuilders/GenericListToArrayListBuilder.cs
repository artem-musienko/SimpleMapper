using System;
using System.Collections;
using System.Linq.Expressions;
using SimpleMapper.Configuration;

namespace SimpleMapper.ExpressionBuilders
{
    internal sealed class GenericListToArrayListBuilder : ExpressionBuilder
    {
        protected override Expression Build(Expression input, Type inputType, Type targetType, InternalMapperConfig config)
        {
            var inputElementTypes = inputType.GetGenericArguments();
            var targetElementType = typeof(object);
            if (inputElementTypes.Length != 1)
            {
                throw new NotSupportedException(string.Format("Wrong generic arguments count. 1 expected, {0} found",
                    inputElementTypes.Length));
            }

            var i = Expression.Variable(typeof(int), string.Format("i{0}", config.CurrentDepthLevel));
            var list = Expression.Variable(targetType, string.Format("list{0}", config.CurrentDepthLevel));

            // listCount = inputArray.Count
            var listCount = Expression.Property(input, "Count");
            // list = new ArrayList(arrLength)
            var listCtor = typeof(ArrayList).GetConstructor(new[] { typeof(int) });
            if (listCtor == null)
            {
                throw new NotSupportedException(string.Format("Unable to find ctor of type {0} with signature (int capacity)", targetType));
            }
            var listAssign = Expression.Assign(list, Expression.New(listCtor, listCount));
            var assignLoopVariable = i.Assign(0.Constant());
            var breakLabel = Expression.Label(targetType);
            // list.Add(MapperFactory.CreateExpression<inputElementType, targetElementType>(inputArray[i]))
            var addValue = Expression.Call(list, targetType.GetMethod("Add"),
                MapperFactory.CreateExpression(input.IndexerAccess(i), inputElementTypes[0], targetElementType, config.NextDepthLevel()));
            // i++
            var increment = Expression.PostIncrementAssign(i);
            var gotoBreak = Expression.Goto(breakLabel, list);
            // if (i >= arrLength) break
            var checkArrayBounds = Expression.IfThen(Expression.GreaterThanOrEqual(i, listCount), gotoBreak);
            var loopBody = Expression.Block(checkArrayBounds, addValue, increment);
            var loop = Expression.Loop(loopBody, breakLabel);
            // int i = 0; {  while (true) { if (i>=inputArray.Length) goto break; { arr[i] = converter(inputArray[i]); i++; } } }
            var loopBlock = Expression.Block(new[] { i }, assignLoopVariable, loop);
            //return input.TernaryNullCheck(targetType.Default(), listAssign);
            return input.TernaryNullCheck(targetType.Default(), Expression.Block(new[] { list }, listAssign, loopBlock));
        }
    }
}