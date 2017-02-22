using System;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    public class Mapping_arrays
    {
        public const int MAX_ARRAY_LENGTH = 125;

        #region Classes

        private class ClassA
        {
            public int Number { get; set; }
            public int[] Ints { get; set; }
        }

        private class ClassB
        {
            public string Number { get; set; }
            public string[] Ints { get; set; }
        }

        #endregion

        [Test]
        public void Map_array_of_the_same_type()
        {
            var testArray = ((int)MAX_ARRAY_LENGTH.Random()).CreateArray(i => (int)MAX_ARRAY_LENGTH.Random());
            testArray.TestMapper<int[], int[]>((ints1, ints2) => ints1.AreEqual(ints2, (arg, i) => arg == i),
                                                 "Ints to ints");
        }

        [Test]
        public void Map_array_of_numeric()
        {
            var testArray = ((int)MAX_ARRAY_LENGTH.Random()).CreateArray(i => MAX_ARRAY_LENGTH.Random());
            testArray.TestMapper<sbyte[], int[]>((sbytes, ints) => sbytes.AreEqual(ints, (arg, i) => arg == i),
                                                 "Sbytes to ints");
        }

        [Test]
        public void Map_multidimensional_arrays()
        {
            var dimensions = 3.CreateArray(i => MAX_ARRAY_LENGTH.Random());
            var matrix1 = new sbyte[dimensions[0], dimensions[1], dimensions[2]];
            var matrix2 = new sbyte[dimensions[0]][][];
            for (int i = 0; i < dimensions[0]; i++)
            {
                matrix2[i] = new sbyte[dimensions[1]][];
                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix2[i][j] = new sbyte[dimensions[2]];
                    for (int k = 0; k < dimensions[2]; k++)
                    {
                        matrix1[i, j, k] = MAX_ARRAY_LENGTH.Random();
                        matrix2[i][j][k] = MAX_ARRAY_LENGTH.Random();
                    }
                }
            }

            matrix1.TestMapper<sbyte[, ,], int[, ,]>((sbytes, ints) =>
                {
                    for (int i = 0; i < dimensions[0]; i++)
                    {
                        for (int j = 0; j < dimensions[1]; j++)
                        {
                            for (int k = 0; k < dimensions[2]; k++)
                            {
                                if (sbytes[i, j, k] !=
                                    ints[i, j, k])
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    return true;
                }, "Sbyte[,,] to int[,,]");

            matrix2.TestMapper<sbyte[][][], int[][][]>((sbytes, ints) =>
                {
                    for (int i = 0; i < dimensions[0]; i++)
                    {
                        for (int j = 0; j < dimensions[1]; j++)
                        {
                            for (int k = 0; k < dimensions[2]; k++)
                            {
                                try
                                {
                                    if (sbytes[i][j][k] != ints[i][j][k])
                                    {
                                        return false;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                            }
                        }
                    }
                    return true;
                }, "Sbyte[][][] to int[][][]");
        }

        [Test]
        public void Map_arrays_of_objects()
        {
            var testArray = ((int)MAX_ARRAY_LENGTH.Random()).CreateArray(i => new ClassA { Number = i });
            testArray.TestMapper<ClassA[], ClassB[]>(
                (@as, bs) => @as.AreEqual(bs, (a, b) => a.Number == Int32.Parse(b.Number)), "ClassA[] to ClassB[]");
        }

        [Test]
        public void Map_properties_of_array_type()
        {
            var test = new ClassA { Ints = ((int)MAX_ARRAY_LENGTH.Random()).CreateArray(i => (int) 10.Random()) };
            test.TestMapper<ClassA, ClassB>(
                (a, b) => b != null && b.Ints.AreEqual(a.Ints, (s, i) => Int32.Parse(s) == i),
                "Property int[] to property string[]");
        }
     
    }
}
