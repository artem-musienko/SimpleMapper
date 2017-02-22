using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleMapper.Tests
{
    [TestClass]
    public class ValueTypes
    {
        public const byte MAX = 100;
        public const double EPSILON = 0.001;

        [TestMethod]
        public void Byte_types_mapping()
        {
            ((byte)MAX.Random()).TestMapper<byte, byte>((a, b) => a == b, "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, sbyte>((a, b) => a == b, "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, short>((a, b) => a == b, "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, ushort>((a, b) => a == b, "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, int>((a, b) => a == b, "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, uint>((a, b) => a == b, "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, long>((a, b) => a == b, "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, ulong>((a, b) => a == b, "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, decimal>((a, b) => a == b, "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, float>((a, b) => 0 == b.CompareTo(a), "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, double>((a, b) => 0 == b.CompareTo(a), "Byte_types_mapping");
            ((byte)MAX.Random()).TestMapper<byte, char>((a, b) => a == b, "Byte_types_mapping");
        }

        [TestMethod]
        public void Sbyte_types_mapping()
        {
            ((sbyte)MAX.Random()).TestMapper<sbyte, byte>((a, b) => a == b, "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, sbyte>((a, b) => a == b, "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, short>((a, b) => a == b, "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, ushort>((a, b) => a == b, "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, int>((a, b) => a == b, "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, uint>((a, b) => a == b, "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, long>((a, b) => a == b, "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, ulong>((a, b) => (ulong)a == b, "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, decimal>((a, b) => a == b, "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, float>((a, b) => 0 == b.CompareTo(a), "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, double>((a, b) => 0 == b.CompareTo(a), "Sbyte_types_mapping");
            ((sbyte)MAX.Random()).TestMapper<sbyte, char>((a, b) => a == b, "Sbyte_types_mapping");
        }

        [TestMethod]
        public void Short_types_mapping()
        {
            ((short)MAX.Random()).TestMapper<short, byte>((a, b) => a == b, "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, sbyte>((a, b) => a == b, "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, short>((a, b) => a == b, "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, ushort>((a, b) => a == b, "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, int>((a, b) => a == b, "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, uint>((a, b) => a == b, "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, long>((a, b) => a == b, "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, ulong>((a, b) => (ulong)a == b, "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, decimal>((a, b) => a == b, "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, float>((a, b) => 0 == b.CompareTo(a), "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, double>((a, b) => 0 == b.CompareTo(a), "Short_types_mapping");
            ((short)MAX.Random()).TestMapper<short, char>((a, b) => a == b, "Short_types_mapping");
        }

        [TestMethod]
        public void Char_types_mapping()
        {
            ((char)MAX.Random()).TestMapper<char, byte>((a, b) => a == b, "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, sbyte>((a, b) => a == b, "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, short>((a, b) => a == b, "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, ushort>((a, b) => a == b, "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, int>((a, b) => a == b, "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, uint>((a, b) => a == b, "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, long>((a, b) => a == b, "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, ulong>((a, b) => a == b, "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, decimal>((a, b) => a == b, "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, float>((a, b) => 0 == b.CompareTo(a), "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, double>((a, b) => 0 == b.CompareTo(a), "Char_types_mapping");
            ((char)MAX.Random()).TestMapper<char, char>((a, b) => a == b, "Char_types_mapping");
        }

        [TestMethod]
        public void Decimal_types_mapping()
        {
            ((decimal)MAX.Random()).TestMapper<decimal, byte>((a, b) => a == b, "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, sbyte>((a, b) => a == b, "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, short>((a, b) => a == b, "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, ushort>((a, b) => a == b, "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, int>((a, b) => a == b, "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, uint>((a, b) => a == b, "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, long>((a, b) => a == b, "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, ulong>((a, b) => a == b, "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, decimal>((a, b) => a == b, "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, float>((a, b) => 0 == b.CompareTo(a), "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, double>((a, b) => 0 == b.CompareTo(a), "Decimal_types_mapping");
            ((decimal)MAX.Random()).TestMapper<decimal, char>((a, b) => a == b, "Decimal_types_mapping");
        }

        [TestMethod]
        public void Double_types_mapping()
        {
            ((double)MAX.Random()).TestMapper<double, byte>((a, b) => Math.Abs(a - b) < EPSILON, "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, sbyte>((a, b) => Math.Abs(a - b) < EPSILON, "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, short>((a, b) => Math.Abs(a - b) < EPSILON, "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, ushort>((a, b) => Math.Abs(a - b) < EPSILON, "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, int>((a, b) => Math.Abs(a - b) < EPSILON, "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, uint>((a, b) => Math.Abs(a - b) < EPSILON, "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, long>((a, b) => Math.Abs(a - b) < EPSILON, "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, ulong>((a, b) => Math.Abs(a - b) < EPSILON, "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, decimal>((a, b) => Math.Abs(a - (double) b) < EPSILON, "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, float>((a, b) => 0 == b.CompareTo(a), "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, double>((a, b) => 0 == b.CompareTo(a), "Double_types_mapping");
            ((double)MAX.Random()).TestMapper<double, char>((a, b) => Math.Abs(a - b) < EPSILON, "Double_types_mapping");
        }

        [TestMethod]
        public void Float_types_mapping()
        {
            ((float)MAX.Random()).TestMapper<float, byte>((a, b) => Math.Abs(a - b) < EPSILON, "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, sbyte>((a, b) => Math.Abs(a - b) < EPSILON, "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, short>((a, b) => Math.Abs(a - b) < EPSILON, "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, ushort>((a, b) => Math.Abs(a - b) < EPSILON, "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, int>((a, b) => Math.Abs(a - b) < EPSILON, "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, uint>((a, b) => Math.Abs(a - b) < EPSILON, "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, long>((a, b) => Math.Abs(a - b) < EPSILON, "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, ulong>((a, b) => Math.Abs(a - b) < EPSILON, "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, decimal>((a, b) => Math.Abs(a - (float)b) < EPSILON, "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, float>((a, b) => 0 == b.CompareTo(a), "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, double>((a, b) => 0 == b.CompareTo(a), "Float_types_mapping");
            ((float)MAX.Random()).TestMapper<float, char>((a, b) => Math.Abs(a - b) < EPSILON, "Float_types_mapping");
        }

        [TestMethod]
        public void Int_types_mapping()
        {
            MAX.Random().TestMapper<int, byte>((a, b) => a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, sbyte>((a, b) => a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, short>((a, b) => a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, ushort>((a, b) => a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, int>((a, b) => a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, uint>((a, b) => a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, long>((a, b) => a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, ulong>((a, b) => (ulong)a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, ulong>((a, b) => (ulong)a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, decimal>((a, b) => a == b, "Int_types_mapping");
            MAX.Random().TestMapper<int, float>((a, b) => 0 == b.CompareTo(a), "Int_types_mapping");
            MAX.Random().TestMapper<int, double>((a, b) => 0 == b.CompareTo(a), "Int_types_mapping");
            MAX.Random().TestMapper<int, char>((a, b) => a == b, "Int_types_mapping");
        }

        [TestMethod]
        public void Uint_types_mapping()
        {
            ((uint)MAX.Random()).TestMapper<uint, byte>((a, b) => a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, sbyte>((a, b) => a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, short>((a, b) => a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, ushort>((a, b) => a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, int>((a, b) => a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, uint>((a, b) => a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, long>((a, b) => a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, ulong>((a, b) => (ulong)a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, ulong>((a, b) => (ulong)a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, decimal>((a, b) => a == b, "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, float>((a, b) => 0 == b.CompareTo(a), "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, double>((a, b) => 0 == b.CompareTo(a), "Uint_types_mapping");
            ((uint)MAX.Random()).TestMapper<uint, char>((a, b) => a == b, "Uint_types_mapping");
        }

        [TestMethod]
        public void Long_types_mapping()
        {
            ((long)MAX.Random()).TestMapper<long, byte>((a, b) => a == b, "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, sbyte>((a, b) => a == b, "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, short>((a, b) => a == b, "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, ushort>((a, b) => a == b, "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, int>((a, b) => a == b, "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, uint>((a, b) => a == b, "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, long>((a, b) => a == b, "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, ulong>((a, b) => (ulong)a == b, "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, decimal>((a, b) => a == b, "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, float>((a, b) => 0 == b.CompareTo(a), "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, double>((a, b) => 0 == b.CompareTo(a), "Long_types_mapping");
            ((long)MAX.Random()).TestMapper<long, char>((a, b) => a == b, "Long_types_mapping");
        }

        [TestMethod]
        public void Ulong_types_mapping()
        {
            ((ulong)MAX.Random()).TestMapper<ulong, byte>((a, b) => a == b, "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, sbyte>((a, b) => a == (ulong)b, "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, short>((a, b) => a == (ulong)b, "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, ushort>((a, b) => a == (ulong)b, "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, int>((a, b) => a == (ulong)b, "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, uint>((a, b) => a == b, "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, long>((a, b) => a == (ulong)b, "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, ulong>((a, b) => a == b, "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, decimal>((a, b) => a == b, "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, float>((a, b) => 0 == b.CompareTo(a), "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, double>((a, b) => 0 == b.CompareTo(a), "Ulong_types_mapping");
            ((ulong)MAX.Random()).TestMapper<ulong, char>((a, b) => a == b, "Ulong_types_mapping");
        }
    }
}
