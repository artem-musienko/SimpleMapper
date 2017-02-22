using System;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    
    public class Mapping_from_nullable_to_builtIn
    {
        public const int MAX = 100;
        public const double TOLERANCE = 0.000001;
        // ReSharper disable PossibleInvalidOperationException
        [Test]
        public void Map_from_nullable_byte()
        {
            ((byte?)MAX.Random()).TestMapper<byte?, byte>((a, b) => a == b, "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, sbyte>((a, b) => a == b, "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, short>((a, b) => a == b, "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, ushort>((a, b) => a == b, "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, int>((a, b) => a == b, "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, uint>((a, b) => a == b, "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, long>((a, b) => a == b, "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, ulong>((a, b) => a == b, "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, decimal>((a, b) => a == b, "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, float>((a, b) => 0 == b.CompareTo((byte)a), "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, double>((a, b) => 0 == b.CompareTo((byte)a), "Byte mapping");
            ((byte?)MAX.Random()).TestMapper<byte?, char>((a, b) => a == b, "Byte mapping");
        }

        [Test]
        public void Map_from_nullable_sbyte()
        {
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, byte>((a, b) => a == b, "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, sbyte>((a, b) => a == b, "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, short>((a, b) => a == b, "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, ushort>((a, b) => a == b, "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, int>((a, b) => a == b, "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, uint>((a, b) => a == b, "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, long>((a, b) => a == b, "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, ulong>((a, b) => (ulong)a == b, "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, decimal>((a, b) => a == b, "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, float>((a, b) => 0 == b.CompareTo((sbyte)a), "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, double>((a, b) => 0 == b.CompareTo((sbyte)a), "Sbyte mapping");
            ((sbyte?)MAX.Random()).TestMapper<sbyte?, char>((a, b) => a == b, "Sbyte mapping");
        }

        [Test]
        public void Map_from_nullable_int16()
        {
            ((short?)MAX.Random()).TestMapper<short?, byte>((a, b) => a == b, "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, sbyte>((a, b) => a == b, "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, short>((a, b) => a == b, "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, ushort>((a, b) => a == b, "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, int>((a, b) => a == b, "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, uint>((a, b) => a == b, "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, long>((a, b) => a == b, "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, ulong>((a, b) => (ulong)a == b, "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, decimal>((a, b) => a == b, "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, float>((a, b) => 0 == b.CompareTo((short)a), "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, double>((a, b) => 0 == b.CompareTo((short)a), "Int16 mapping");
            ((short?)MAX.Random()).TestMapper<short?, char>((a, b) => a == b, "Int16 mapping");
        }

        [Test]
        public void Map_from_nullable_char()
        {
            ((char?)MAX.Random()).TestMapper<char?, byte>((a, b) => a == b, "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, sbyte>((a, b) => a == b, "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, short>((a, b) => a == b, "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, ushort>((a, b) => a == b, "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, int>((a, b) => a == b, "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, uint>((a, b) => a == b, "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, long>((a, b) => a == b, "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, ulong>((a, b) => a == b, "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, decimal>((a, b) => a == b, "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, float>((a, b) => 0 == b.CompareTo((char)a), "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, double>((a, b) => 0 == b.CompareTo((char)a), "Char mapping");
            ((char?)MAX.Random()).TestMapper<char?, char>((a, b) => a == b, "Char mapping");
        }

        [Test]
        public void Map_from_nullable_decimal()
        {
            ((decimal?)MAX.Random()).TestMapper<decimal?, byte>((a, b) => a == b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, sbyte>((a, b) => a == b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, short>((a, b) => a == b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, ushort>((a, b) => a == b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, int>((a, b) => a == b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, uint>((a, b) => a == b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, long>((a, b) => a == b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, ulong>((a, b) => a == b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, decimal>((a, b) => a == b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, float>((a, b) => a == (decimal)b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, double>((a, b) => a == (decimal)b, "Decimal mapping");
            ((decimal?)MAX.Random()).TestMapper<decimal?, char>((a, b) => a == b, "Decimal mapping");
        }

        [Test]
        public void Map_from_nullable_double()
        {
            ((double?)MAX.Random()).TestMapper<double?, byte>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, sbyte>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, short>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, ushort>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, int>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, uint>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, long>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, ulong>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, decimal>((a, b) => Math.Abs((double)a - (double)b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, float>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, double>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
            ((double?)MAX.Random()).TestMapper<double?, char>((a, b) => Math.Abs((double)a - b) < TOLERANCE, "Double mapping");
        }

        [Test]
        public void Map_from_nullable_float()
        {
            ((float?)MAX.Random()).TestMapper<float?, byte>((a, b) => Math.Abs((float)a - b) < TOLERANCE, "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, sbyte>((a, b) => Math.Abs((float)a - b) < TOLERANCE, "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, short>((a, b) => Math.Abs((float)a - b) < TOLERANCE, "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, ushort>((a, b) => Math.Abs((float)a - b) < TOLERANCE, "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, int>((a, b) => Math.Abs((float)a - b) < TOLERANCE, "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, uint>((a, b) => Math.Abs((float)a - b) < TOLERANCE, "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, long>((a, b) => Math.Abs((float)a - b) < TOLERANCE, "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, ulong>((a, b) => Math.Abs((float)a - b) < TOLERANCE, "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, decimal>((a, b) => Math.Abs((float)a - (float)b) < TOLERANCE, "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, float>((a, b) => 0 == b.CompareTo((float)a), "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, double>((a, b) => 0 == b.CompareTo((float)a), "Float mapping");
            ((float?)MAX.Random()).TestMapper<float?, char>((a, b) => Math.Abs((float)a - b) < TOLERANCE, "Float mapping");
        }

        [Test]
        public void Map_from_nullable_int32()
        {
            ((int?)MAX.Random()).TestMapper<int?, byte>((a, b) => a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, sbyte>((a, b) => a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, short>((a, b) => a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, ushort>((a, b) => a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, int>((a, b) => a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, uint>((a, b) => a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, long>((a, b) => a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, ulong>((a, b) => (ulong)a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, ulong>((a, b) => (ulong)a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, decimal>((a, b) => a == b, "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, float>((a, b) => 0 == b.CompareTo((int)a), "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, double>((a, b) => 0 == b.CompareTo((int)a), "Int32 mapping");
            ((int?)MAX.Random()).TestMapper<int?, char>((a, b) => a == b, "Int32 mapping");
        }

        [Test]
        public void Map_from_nullable_uint32()
        {
            ((uint?)MAX.Random()).TestMapper<uint?, byte>((a, b) => a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, sbyte>((a, b) => a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, short>((a, b) => a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, ushort>((a, b) => a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, int>((a, b) => a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, uint>((a, b) => a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, long>((a, b) => a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, ulong>((a, b) => (ulong)a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, ulong>((a, b) => (ulong)a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, decimal>((a, b) => a == b, "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, float>((a, b) => 0 == b.CompareTo((uint)a), "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, double>((a, b) => 0 == b.CompareTo((uint)a), "UInt32 mapping");
            ((uint?)MAX.Random()).TestMapper<uint?, char>((a, b) => a == b, "UInt32 mapping");
        }

        [Test]
        public void Map_from_nullable_int64()
        {
            ((long?)MAX.Random()).TestMapper<long?, byte>((a, b) => a == b, "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, sbyte>((a, b) => a == b, "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, short>((a, b) => a == b, "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, ushort>((a, b) => a == b, "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, int>((a, b) => a == b, "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, uint>((a, b) => a == b, "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, long>((a, b) => a == b, "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, ulong>((a, b) => (ulong?)a == b, "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, decimal>((a, b) => a == b, "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, float>((a, b) => 0 == b.CompareTo((long)a), "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, double>((a, b) => 0 == b.CompareTo((long)a), "Int64 mapping");
            ((long?)MAX.Random()).TestMapper<long?, char>((a, b) => a == b, "Int64 mapping");
        }

        [Test]
        public void Map_from_nullable_uint64()
        {
            ((ulong?)MAX.Random()).TestMapper<ulong?, byte>((a, b) => a == b, "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, sbyte>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, short>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, ushort>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, int>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, uint>((a, b) => a == b, "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, long>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, ulong>((a, b) => a == b, "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, decimal>((a, b) => a == b, "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, float>((a, b) => 0 == b.CompareTo((ulong)a), "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, double>((a, b) => 0 == b.CompareTo((ulong)a), "UInt62 mapping");
            ((ulong?)MAX.Random()).TestMapper<ulong?, char>((a, b) => a == b, "UInt62 mapping");
        }
        // ReSharper restore PossibleInvalidOperationException
    }
}
