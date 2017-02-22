using System;
using System.Collections.Specialized;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleMapper.Tests.Collections
{
    [TestClass]
    public class NameValueCollections
    {
        private class TestA
        {
            public enum TestEnum
            {
                ValueOne,
                ValueTwo
            }

            public int Field1 { get; set; }
            public DateTime? Field2 { get; set; }
            public DateTime? Field3 { get; set; }
            public int Field4 { get; set; }
            public int? Field5 { get; set; }
            public string Field6 { get; set; }
            public TestEnum Field7 { get; set; }
            public TestEnum Field8 { get; set; }
            public TestEnum? Field9 { get; set; }

            public TestA()
            {
                Field4 = -1;
                Field8 = TestEnum.ValueTwo;
            }
        }

        [TestMethod]
        public void ToClass()
        {
            var now = DateTime.Now;
            var nvc = new NameValueCollection
                {
                    {"Field1", "5"},
                    {"Field2", now.ToString(CultureInfo.InstalledUICulture)},
                    {"Field3", "wrong DateTime"},
                    {"Field4", "wrong int"},
                    {"Field5", "wrong int"},
                    {"Field6", "test string"},
                    {"Field7", "ValueTwo"},
                    {"Field8", "wrong enum"},
                    {"Field9", "wrong enum"},
                };
            nvc.TestMapper<NameObjectCollectionBase, TestA>((@base, a) =>
                {
                    if (a == null) { return false; }
                    if (a.Field1 != 5) { return false; }
                    if (a.Field2 == null || a.Field2 != now) { return false; }
                    if (a.Field3 != null) { return false; }
                    if (a.Field4 != -1) { return false; }
                    if (a.Field5 != null) { return false; }
                    if (a.Field6 != "test string") { return false; }
                    if (a.Field7 != TestA.TestEnum.ValueTwo) { return false; }
                    if (a.Field8 != TestA.TestEnum.ValueTwo) { return false; }
                    if (a.Field9 != null) { return false; }
                    return true;
                }, "NameObjectCollectionBase to Class");

            nvc.TestMapper<NameValueCollection, TestA>((@base, a) =>
                {
                    if (a == null) { return false; }
                    if (a.Field1 != 5) { return false; }
                    if (a.Field2 == null || a.Field2 != now) { return false; }
                    if (a.Field3 != null) { return false; }
                    if (a.Field4 != -1) { return false; }
                    if (a.Field5 != null) { return false; }
                    if (a.Field6 != "test string") { return false; }
                    if (a.Field7 != TestA.TestEnum.ValueTwo) { return false; }
                    if (a.Field8 != TestA.TestEnum.ValueTwo) { return false; }
                    if (a.Field9 != null) { return false; }
                    return true;
                }, "NameValueCollection to Class");
        }
    }
}