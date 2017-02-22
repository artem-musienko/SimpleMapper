
using System;
using NUnit.Framework;
using SimpleMapper.Configuration;

namespace SimpleMapper.Tests
{
    public sealed class MappingConfiguration_equality
    {
        private void AssertMapperComparer<TIn, TOut>(
            MappingConfiguration<TIn, TOut> config1, 
            MappingConfiguration<TIn, TOut> config2,
            bool hashesAreEqual = true,
            bool areEqual = true)
        {
            var comparer = MapperComparer<TIn, TOut>.Instance;
            if (hashesAreEqual)
            {
                Assert.AreEqual(comparer.GetHashCode(config1), comparer.GetHashCode(config2));
            }
            else
            {
                Assert.AreNotEqual(comparer.GetHashCode(config1), comparer.GetHashCode(config2));
            }

            if (areEqual)
            {
                Assert.IsTrue(comparer.Equals(config1, config2), "expected:\r\n{0}\r\nactual:\r\n{1}", config1.Value, config2.Value);
            }
            else
            {
                Assert.IsFalse(comparer.Equals(config1, config2), "expected:\r\n{0}\r\nactual:\r\n{1}", config1.Value, config2.Value);
            }
        }

        [Test]
        public void MappingComparer_returns_false_with_ignore_against_empty()
        {
            var config1 = new MappingConfiguration<Person, Employee>();
            var config2 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.Id);
            AssertMapperComparer(config1, config2, true, false);
        }

        [Test]
        public void MappingComparer_returns_true_for_the_same_ignore()
        {
            var config1 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.Id);
            var config2 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.Id);
            AssertMapperComparer(config1, config2);
        }

        [Test]
        public void MappingComparer_returns_true_for_the_same_ignores()
        {
            var config1 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.Id)
                .Ignore(employee => employee.FirstName);
            var config2 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.FirstName)
                .Ignore(employee => employee.Id);
            AssertMapperComparer(config1, config2);
        }

        [Test]
        public void MappingComparer_returns_true_for_duplicate_ignores()
        {
            var config1 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.Id)
                .Ignore(employee => employee.Id);
            var config2 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.Id);
            AssertMapperComparer(config1, config2);
        }

        [Test]
        public void MappingComparer_returns_false_for_different_ignores()
        {
            var config1 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.Id);
            var config2 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.FirstName);
            var config3 = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.Id)
                .Ignore(employee => employee.FirstName);
            AssertMapperComparer(config1, config2, true, false);
            AssertMapperComparer(config1, config3, true, false);
            AssertMapperComparer(config2, config3, true, false);
        }

        [Test]
        public void MappingComparer_returns_false_for_the_forProperty_against_empty()
        {
            var config1 = new MappingConfiguration<Person, Employee>();
            var config2 = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.Id, person => person.Id + 1);
            AssertMapperComparer(config1, config2, true, false);
        }

        [Test]
        public void MappingComparer_returns_true_for_the_same_forProperty()
        {
            Func<Person, int> func = person => person.Id + 1;
            var config1 = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.Id, func);
            var config2 = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.Id, func);
            AssertMapperComparer(config1, config2);
        }

        [Test]
        public void MappingComparer_returns_true_for_the_different_forProperty()
        {
            var config1 = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.Id, person => person.Id + 1);
            var config2 = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.Id, person => person.Id + 2);
            AssertMapperComparer(config1, config2, true, false);
        }

        [Test]
        public void MappingComparer_returns_false_for_the_same_forProperty_for_different_properties()
        {
            Func<Person, string> func = person => person.FirstName + " ";
            var config1 = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.FirstName, func);
            var config2 = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.LastName, func);
            AssertMapperComparer(config1, config2, true, false);
        }

        [Test]
        public void MappingComparer_returns_true_for_the_same_forProperties()
        {
            Func<Person, int> func1 = person => person.Id + 1;
            Func<Person, string> func2 = person => person.FirstName + " ";
            var config1 = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.FirstName, func2)
                .ForProperty(employee => employee.Id, func1);
            var config2 = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.Id, func1)
                .ForProperty(employee => employee.FirstName, func2);
            AssertMapperComparer(config1, config2);
        }

    }
}