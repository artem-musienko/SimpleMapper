using System;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    public class Mapping_using_boxing_and_unboxing
    {
        public const int MAX = 100;

        public const double TOLERANCE = 0.000001;

        [Test]
        public void Numeric_types_boxing()
        {
            var a1 = MAX.Random();

            ((byte)a1).TestMapper<byte, object>((b, o) => b == (byte)o, "Byte boxing");
            ((sbyte)a1).TestMapper<sbyte, object>((b, o) => b == (sbyte)o, "SByte boxing");
            ((short)a1).TestMapper<short, object>((b, o) => b == (short)o, "Int16 boxing");
            ((ushort)a1).TestMapper<ushort, object>((b, o) => b == (ushort)o, "UInt16 boxing");
            ((int)a1).TestMapper<int, object>((b, o) => b == (int)o, "Int32 boxing");
            ((uint)a1).TestMapper<uint, object>((b, o) => b == (uint)o, "UInt32 boxing");
            ((long)a1).TestMapper<long, object>((b, o) => b == (long)o, "Int64 boxing");
            ((ulong)a1).TestMapper<ulong, object>((b, o) => b == (ulong)o, "UInt64 boxing");
            ((char)a1).TestMapper<char, object>((b, o) => b == (char)o, "Char boxing");
            ((float)a1).TestMapper<float, object>((b, o) => Math.Abs(b - (float)o) < TOLERANCE, "Float boxing");
            ((double)a1).TestMapper<double, object>((b, o) => Math.Abs(b - (double)o) < TOLERANCE, "Double boxing");
            ((decimal)a1).TestMapper<decimal, object>((b, o) => b == (decimal)o, "Decimal boxing");
        }

        [Test]
        public void Numeric_types_unboxing()
        {
            object obj;
            obj = ((byte)MAX.Random());
            obj.TestMapper<object, byte>((o, b) => (byte)o == b, "Byte unboxing");
            obj = (sbyte)MAX.Random();
            obj.TestMapper<object, sbyte>((o, b) => (sbyte)o == b, "SByte unboxing");
            obj = (short)MAX.Random();
            obj.TestMapper<object, short>((o, b) => (short)o == b, "Int16 unboxing");
            obj = (ushort)MAX.Random();
            obj.TestMapper<object, ushort>((o, b) => (ushort)o == b, "UInt16 unboxing");
            obj = (int)MAX.Random();
            obj.TestMapper<object, int>((o, b) => (int)o == b, "Int32 unboxing");
            obj = (uint)MAX.Random();
            obj.TestMapper<object, uint>((o, b) => (uint)o == b, "UInt32 unboxing");
            obj = (long)MAX.Random();
            obj.TestMapper<object, long>((o, b) => (long)o == b, "Int64 unboxing");
            obj = (ulong)MAX.Random();
            obj.TestMapper<object, ulong>((o, b) => (ulong)o == b, "UInt64 unboxing");
            obj = (decimal)(((double)MAX).Random());
            obj.TestMapper<object, decimal>((o, b) => (decimal)o == b, "Decimal unboxing");
            obj = (float)(((double)MAX).Random());
            obj.TestMapper<object, float>((o, b) => Math.Abs((float)o - b) < TOLERANCE, "Single unboxing");
            obj = ((double)MAX).Random();
            obj.TestMapper<object, double>((o, b) => Math.Abs((double)o - b) < TOLERANCE, "Double unboxing");
            obj = (char)MAX.Random();
            obj.TestMapper<object, char>((o, b) => (char)o == b, "Char unboxing");
        }

        [Test]
        public void Numeric_types_from_object_using_convert()
        {
            object obj;
            obj = MAX.Random();
            obj.TestMapper<object, byte>((o, b) => Convert.ToByte(o) == b, "Byte convert");
            obj = (byte)(MAX.Random());
            obj.TestMapper<object, sbyte>((o, b) => Convert.ToSByte(o) == b, "SByte convert");
            obj = MAX.Random();
            obj.TestMapper<object, short>((o, b) => Convert.ToInt16(o) == b, "Int16 convert");
            obj.TestMapper<object, ushort>((o, b) => Convert.ToUInt16(o) == b, "UInt16 convert");
            obj.TestMapper<object, int>((o, b) => Convert.ToInt32(o) == b, "Int32 convert");
            obj.TestMapper<object, uint>((o, b) => Convert.ToUInt32(o) == b, "UInt32 convert");
            obj.TestMapper<object, long>((o, b) => Convert.ToInt64(o) == b, "Int64 convert");
            obj.TestMapper<object, ulong>((o, b) => Convert.ToUInt64(o) == b, "UInt64 convert");

            obj.TestMapper<object, char>((o, b) => Convert.ToChar(o) == b, "Char convert");

            obj = ((double)MAX).Random();
            obj.TestMapper<object, decimal>((o, b) => Convert.ToDecimal(o) == b, "Decimal convert");
            obj.TestMapper<object, float>((o, b) => Math.Abs(Convert.ToSingle(o) - b) < TOLERANCE, "Single convert");
            obj = (float)(((double)MAX).Random());
            obj.TestMapper<object, double>((o, b) => Math.Abs(Convert.ToDouble(o) - b) < TOLERANCE, "Double convert");


        }
    }
}