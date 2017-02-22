using System;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    public class Mapping_enums_to_and_from_numeric
    {
        [Test]
        public void Map_from_enum_to_numeric()
        {
            var e = (Enums.English)4.Random();
            e.TestMapper<Enums.English, byte>((english, b) => e == (Enums.English)b && Enum.IsDefined(typeof(Enums.English), (int)b), "Enum to byte");
            e.TestMapper<Enums.English, sbyte>((english, b) => e == (Enums.English)b && Enum.IsDefined(typeof(Enums.English), (int)b), "Enum to short");
            e.TestMapper<Enums.English, ushort>((english, b) => e == (Enums.English)b && Enum.IsDefined(typeof(Enums.English), (int)b), "Enum to ushort");
            e.TestMapper<Enums.English, int>((english, b) => e == (Enums.English)b && Enum.IsDefined(typeof(Enums.English), (int)b), "Enum to int");
            e.TestMapper<Enums.English, uint>((english, b) => e == (Enums.English)b && Enum.IsDefined(typeof(Enums.English), (int)b), "Enum to uint");
            e.TestMapper<Enums.English, long>((english, b) => e == (Enums.English)b && Enum.IsDefined(typeof(Enums.English), (int)b), "Enum to long");
            e.TestMapper<Enums.English, ulong>((english, b) => e == (Enums.English)b && Enum.IsDefined(typeof(Enums.English), (int)b), "Enum to ulong");
            e.TestMapper<Enums.English, char>((english, b) => e == (Enums.English)b, "Enum to char");
        }

        [Test]
        public void Map_from_custom_enum_to_numeric()
        {
            var e = (Enums.Multiplied)(10 * (4.Random()));
            e.TestMapper<Enums.Multiplied, byte>((english, b) => e == (Enums.Multiplied)b && Enum.IsDefined(typeof(Enums.Multiplied), (int)b), "Enum to byte");
            e.TestMapper<Enums.Multiplied, sbyte>((english, b) => e == (Enums.Multiplied)b && Enum.IsDefined(typeof(Enums.Multiplied), (int)b), "Enum to sbyte");
            e.TestMapper<Enums.Multiplied, short>((english, b) => e == (Enums.Multiplied)b && Enum.IsDefined(typeof(Enums.Multiplied), (int)b), "Enum to short");
            e.TestMapper<Enums.Multiplied, ushort>((english, b) => e == (Enums.Multiplied)b && Enum.IsDefined(typeof(Enums.Multiplied), (int)b), "Enum to ushort");
            e.TestMapper<Enums.Multiplied, int>((english, b) => e == (Enums.Multiplied)b && Enum.IsDefined(typeof(Enums.Multiplied), (int)b), "Enum to int");
            e.TestMapper<Enums.Multiplied, uint>((english, b) => e == (Enums.Multiplied)b && Enum.IsDefined(typeof(Enums.Multiplied), (int)b), "Enum to uint");
            e.TestMapper<Enums.Multiplied, long>((english, b) => e == (Enums.Multiplied)b && Enum.IsDefined(typeof(Enums.Multiplied), (int)b), "Enum to long");
            e.TestMapper<Enums.Multiplied, ulong>((english, b) => e == (Enums.Multiplied)b && Enum.IsDefined(typeof(Enums.Multiplied), (int)b), "Enum to ulong");
            e.TestMapper<Enums.Multiplied, char>((english, b) => e == (Enums.Multiplied)b, "Enum to char");
        }

        [Test]
        public void Map_from_numeric_to_enum()
        {
            var input = 4.Random();
            ((byte)input).TestMapper<byte, Enums.Spanish>((b, spanish) => (Enums.Spanish)b == spanish, "Byte to enum");
            ((sbyte)input).TestMapper<sbyte, Enums.Spanish>((b, spanish) => (Enums.Spanish)b == spanish, "SByte to enum");
            ((short)input).TestMapper<short, Enums.Spanish>((b, spanish) => (Enums.Spanish)b == spanish, "Short to enum");
            ((ushort)input).TestMapper<ushort, Enums.Spanish>((b, spanish) => (Enums.Spanish)b == spanish, "Ushort to enum");
            ((int)input).TestMapper<int, Enums.Spanish>((b, spanish) => (Enums.Spanish)b == spanish, "Int to enum");
            ((uint)input).TestMapper<uint, Enums.Spanish>((b, spanish) => (Enums.Spanish)b == spanish, "UInt to enum");
            ((long)input).TestMapper<long, Enums.Spanish>((b, spanish) => (Enums.Spanish)b == spanish, "Long to enum");
            ((ulong)input).TestMapper<ulong, Enums.Spanish>((b, spanish) => (Enums.Spanish)b == spanish, "Ulong to enum");
            ((char)input).TestMapper<char, Enums.Spanish>((b, spanish) => (Enums.Spanish)b == spanish, "Char to enum");
        }

        [Test]
        public void Map_from_numeric_to_custom_enum()
        {
            var input = 10 * (4.Random());
            ((byte)input).TestMapper<byte, Enums.Multiplied>((b, spanish) => (Enums.Multiplied)b == spanish, "Byte to enum");
            ((sbyte)input).TestMapper<sbyte, Enums.Multiplied>((b, spanish) => (Enums.Multiplied)b == spanish, "SByte to enum");
            ((short)input).TestMapper<short, Enums.Multiplied>((b, spanish) => (Enums.Multiplied)b == spanish, "Short to enum");
            ((ushort)input).TestMapper<ushort, Enums.Multiplied>((b, spanish) => (Enums.Multiplied)b == spanish, "Ushort to enum");
            ((int)input).TestMapper<int, Enums.Multiplied>((b, spanish) => (Enums.Multiplied)b == spanish, "Int to enum");
            ((uint)input).TestMapper<uint, Enums.Multiplied>((b, spanish) => (Enums.Multiplied)b == spanish, "UInt to enum");
            ((long)input).TestMapper<long, Enums.Multiplied>((b, spanish) => (Enums.Multiplied)b == spanish, "Long to enum");
            ((ulong)input).TestMapper<ulong, Enums.Multiplied>((b, spanish) => (Enums.Multiplied)b == spanish, "Ulong to enum");
            ((char)input).TestMapper<char, Enums.Multiplied>((b, spanish) => (Enums.Multiplied)b == spanish, "Char to enum");
        }
    }
}
