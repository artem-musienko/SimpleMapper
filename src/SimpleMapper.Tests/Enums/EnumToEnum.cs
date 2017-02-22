using Microsoft.VisualStudio.TestTools.UnitTesting;
using English = SimpleMapper.Tests.Enums.English;
using Spanish = SimpleMapper.Tests.Enums.Spanish;

namespace SimpleMapper.Tests
{
    [TestClass]
    public class EnumToEnum
    {
        [TestMethod]
        public void FromEnumToEnum()
        {
            var e = (English)4.Random();
        }
    }
}