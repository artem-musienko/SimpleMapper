using NUnit.Framework;

namespace SimpleMapper.Tests
{
    
    public class Mapping_enums
    {
        [Test]
        public void Mapping_enum_to_enum()
        {
            var e = (Enums.English)4.Random();
            e.TestMapper<Enums.English, Enums.Spanish>((english, spanish) => (Enums.English)spanish == english, "Enum to enum");
        }
    }
}