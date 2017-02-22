using NUnit.Framework;

namespace SimpleMapper.Tests
{
    
    public class Mapping_nullable_numeric_to_nullable_numeric
    {
        public const int MAX = 100;
        public const double TOLERANCE = 0.000001;
        // ReSharper disable PossibleInvalidOperationException
        [Test]
        public void Byte()
        {
            ((byte?)null).TestMapper<byte?, byte?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, sbyte?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, short?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, ushort?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, int?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, uint?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, long?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, ulong?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, decimal?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, float?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, double?>((a, b) => b == null, "Byte mapping");
            ((byte?)null).TestMapper<byte?, char?>((a, b) => b == null, "Byte mapping");
        }

        [Test]
        public void Sbyte()
        {
            ((sbyte?)null).TestMapper<sbyte?, byte?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, sbyte?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, short?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, ushort?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, int?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, uint?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, long?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, ulong?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, decimal?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, float?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, double?>((a, b) => b == null, "Sbyte mapping");
            ((sbyte?)null).TestMapper<sbyte?, char?>((a, b) => b == null, "Sbyte mapping");
        }

        [Test]
        public void Int16()
        {
            ((short?)null).TestMapper<short?, byte?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, sbyte?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, short?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, ushort?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, int?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, uint?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, long?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, ulong?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, decimal?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, float?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, double?>((a, b) => b == null, "Int16 mapping");
            ((short?)null).TestMapper<short?, char?>((a, b) => b == null, "Int16 mapping");
        }

        [Test]
        public void Char()
        {
            ((char?)null).TestMapper<char?, byte?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, sbyte?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, short?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, ushort?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, int?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, uint?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, long?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, ulong?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, decimal?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, float?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, double?>((a, b) => b == null, "Char mapping");
            ((char?)null).TestMapper<char?, char?>((a, b) => b == null, "Char mapping");
        }

        [Test]
        public void Decimal()
        {
            ((decimal?)null).TestMapper<decimal?, byte?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, sbyte?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, short?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, ushort?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, int?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, uint?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, long?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, ulong?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, decimal?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, float?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, double?>((a, b) => b == null, "Decimal mapping");
            ((decimal?)null).TestMapper<decimal?, char?>((a, b) => b == null, "Decimal mapping");
        }

        [Test]
        public void Double()
        {
            ((double?)null).TestMapper<double?, byte?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, sbyte?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, short?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, ushort?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, int?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, uint?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, long?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, ulong?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, decimal?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, float?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, double?>((a, b) => b == null, "Double mapping");
            ((double?)null).TestMapper<double?, char?>((a, b) => b == null, "Double mapping");
        }

        [Test]
        public void Float()
        {
            ((float?)null).TestMapper<float?, byte?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, sbyte?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, short?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, ushort?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, int?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, uint?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, long?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, ulong?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, decimal?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, float?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, double?>((a, b) => b == null, "Float mapping");
            ((float?)null).TestMapper<float?, char?>((a, b) => b == null, "Float mapping");
        }

        [Test]
        public void Int32()
        {
            ((int?)null).TestMapper<int?, byte?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, sbyte?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, short?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, ushort?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, int?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, uint?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, long?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, ulong?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, ulong?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, decimal?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, float?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, double?>((a, b) => b == null, "Int32 mapping");
            ((int?)null).TestMapper<int?, char?>((a, b) => b == null, "Int32 mapping");
        }

        [Test]
        public void UInt32()
        {
            ((uint?)null).TestMapper<uint?, byte?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, sbyte?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, short?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, ushort?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, int?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, uint?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, long?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, ulong?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, ulong?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, decimal?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, float?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, double?>((a, b) => b == null, "UInt32 mapping");
            ((uint?)null).TestMapper<uint?, char?>((a, b) => b == null, "UInt32 mapping");
        }

        [Test]
        public void Int64()
        {
            ((long?)null).TestMapper<long?, byte?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, sbyte?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, short?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, ushort?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, int?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, uint?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, long?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, ulong?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, decimal?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, float?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, double?>((a, b) => b == null, "Int64 mapping");
            ((long?)null).TestMapper<long?, char?>((a, b) => b == null, "Int64 mapping");
        }

        [Test]
        public void UInt64()
        {
            ((ulong?)null).TestMapper<ulong?, byte?>((a, b) => b == null, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, sbyte?>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, short?>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, ushort?>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, int?>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, uint?>((a, b) => b == null, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, long?>((a, b) => a == (ulong?)b, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, ulong?>((a, b) => b == null, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, decimal?>((a, b) => b == null, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, float?>((a, b) => b == null, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, double?>((a, b) => b == null, "UInt62 mapping");
            ((ulong?)null).TestMapper<ulong?, char?>((a, b) => b == null, "UInt62 mapping");
        }
        // ReSharper restore PossibleInvalidOperationException
    }
}