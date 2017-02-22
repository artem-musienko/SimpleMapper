using System;
using System.Globalization;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    public class Mapping_from_string
    {
        public const int MAX = 100;
        protected const double TOLERANCE = 0.001;

        [Test]
        public void Map_numeric_from_string()
        {
            var str = ((byte)MAX.Random()).ToString(CultureInfo.CurrentCulture);
            var @char = ((char)int.Parse(str)).ToString(CultureInfo.CurrentCulture);

            @char.TestMapper<string, char>((s, a) => char.Parse(s) == a, "String char mapping");
            str.TestMapper<string, sbyte>((s, a) => sbyte.Parse(s) == a, "String sbyte mapping");
            str.TestMapper<string, byte>((s, a) => byte.Parse(s) == a, "String byte mapping");
            str.TestMapper<string, short>((s, a) => short.Parse(s) == a, "String short mapping");
            str.TestMapper<string, ushort>((s, a) => ushort.Parse(s) == a, "String ushort mapping");
            str.TestMapper<string, int>((s, a) => int.Parse(s) == a, "String int mapping");
            str.TestMapper<string, uint>((s, a) => uint.Parse(s) == a, "String uint mapping");
            str.TestMapper<string, long>((s, a) => long.Parse(s) == a, "String long mapping");
            str.TestMapper<string, ulong>((s, a) => ulong.Parse(s) == a, "String ulong mapping");
        }

        [Test]
        public void Map_floats_from_string()
        {
            var strDouble = ((double)MAX).Random().ToString(CultureInfo.CurrentCulture);

            strDouble.TestMapper<string, decimal>((s, d) => decimal.Parse(s) == d, "String decimal mapping");
            strDouble.TestMapper<string, float>((s, d) => Math.Abs(float.Parse(s) - d) < TOLERANCE, "String float mapping");
            strDouble.TestMapper<string, double>((s, d) => Math.Abs(double.Parse(s) - d) < TOLERANCE, "String double mapping");
        }

        [Test]
        public void Map_boolean_from_string()
        {
            var strBool = 2.Random() == 1 ? bool.TrueString : bool.FalseString;
            strBool.TestMapper<string, bool>((s, b) => bool.Parse(s) == b, "String bool mapping");
        }

        [Test]
        public void Map_datetime_from_string()
        {
            var str = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            str.TestMapper<string, DateTime>((s, time) => DateTime.Parse(s) == time, "String to DateTime mapping");
        }
    }
}