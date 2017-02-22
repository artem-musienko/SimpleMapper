using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleMapper.Configuration;

namespace SimpleMapper.Tests
{
    public static class TestHelper
    {
        private static readonly Random random = new Random();

        public static T[] CreateArray<T>(this int length, Func<int, T> elementCreator)
        {
            var result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = elementCreator(i);
            }
            return result;
        }

        public static bool AreEqual<TIn, TOut>(this IList<TIn> input, IList<TOut> output,
                                               Func<TIn, TOut, bool> comparer)
        {
            if (input.Count != output.Count)
            {
                return false;
            }
            var length = input.Count;
            for (int i = 0; i < length; i++)
            {
                if (!comparer(input[i], output[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static sbyte Random(this int to, int from = 1)
        {
            return (sbyte)random.Next(from, to);
        }

        public static double Random(this double to)
        {
            return to * random.NextDouble();
        }

        public static void TestMapper<TIn, TOut>(this TIn input, Func<TIn, TOut, bool> comparer, string testName, MappingConfiguration<TIn, TOut> config = null)
        {
            try
            {
                var output = config == null ? input.Map<TIn, TOut>() : input.Map(config);
                Debug.WriteLine("Expression for mapping {0} into {1}:", typeof(TIn), typeof(TOut));
                Debug.WriteLine(MapperInfo<TIn, TOut>.Default.DebugView);
                Debug.WriteLine(string.Empty);

                var equal = comparer(input, output);
                if (equal)
                {
                    if (ReferenceEquals(input, output) && input != null && input.GetType() != typeof(string))
                    {
                        Assert.Fail("{0} failed: {1} => {2}: objects are the same", testName, typeof(TIn), typeof(TOut));
                    }
                    return;
                }
                Debug.WriteLine("Input: " + input + "\n\rOutput: " + output);
            }
            catch (Exception e)
            {
                while (e != null)
                {
                    Trace.WriteLine(e.Message);
                    e = e.InnerException;
                }
            }
           Assert.Fail("{0} failed: {1} => {2}", testName, typeof(TIn), typeof(TOut));
        }
    }
}