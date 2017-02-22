using System;
using System.Globalization;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    public class Mapping_to_string
    {
        public const int MAX = 100;

        [Test]
        public void Mapping_string_to_datetime()
        {
            var dateTime = DateTime.Now;
            dateTime.TestMapper<DateTime, string>((time, s) => time.ToString(CultureInfo.CurrentCulture) == s, "DateTime to string");
        }

        [Test]
        public void Mapping_string_to_builtin()
        {
            ((byte)MAX.Random()).TestMapper<byte, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "Byte string mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "SByte string mapping");
            ((short)MAX.Random()).TestMapper<short, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "Int16 string mapping");
            ((ushort)MAX.Random()).TestMapper<ushort, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "UInt16 string mapping");
            ((char)MAX.Random()).TestMapper<char, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "Char string mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "Decimal string mapping");
            ((double)MAX.Random()).TestMapper<double, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "Double string mapping");
            ((float)MAX.Random()).TestMapper<float, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "Float string mapping");
            ((int)MAX.Random()).TestMapper<int, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "Int32 string mapping");
            ((uint)MAX.Random()).TestMapper<uint, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "UInt32 string mapping");
            ((long)MAX.Random()).TestMapper<long, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "Int64 string mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "UInt64 string mapping");
            (MAX.Random().ToString()).TestMapper<string, string>((a, s) => a.ToString(CultureInfo.CurrentCulture) == s, "String string mapping");
        }
    }
}