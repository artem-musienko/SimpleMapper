using System;
using NUnit.Framework;
using SimpleMapper.Configuration;

namespace SimpleMapper.Tests
{
    public partial class Mapping_classes
    {
        [Test]
        public void Custom_type_mapping()
        {
            Assert.Inconclusive();
            var input = new Person { Id = 5.Random() };
            var mapperConfig = new MappingConfiguration<Person, Employee>()
                .ForTypes<int, int>(i => i + 5);
            input.TestMapper<Person, Employee>((person, employee) => employee.Id == person.Id + 5, "Custom_type_mapping", mapperConfig);
        }

        [Test]
        public void ForProperty_config_uses_custom_func_when_mapping_property()
        {
            Assert.Inconclusive();
            var input = new Person { FirstName = "John", LastName = "Doe" };
            var mapperConfig = new MappingConfiguration<Person, Employee>()
                .ForProperty(employee => employee.FullName, person => person.FirstName + " " + person.LastName);

            input.TestMapper((person, employee) =>
                employee != null &&
                employee.FirstName == input.FirstName &&
                employee.LastName == input.LastName &&
                employee.Info == null &&
                employee.Id == 0 &&
                employee.FullName == person.FirstName + " " + person.LastName, 
                "ForProperty_config_uses_custom_func_when_mapping_property", mapperConfig);
        }

        [Test]
        public void Aggregate_mapping()
        {
            Assert.Inconclusive();
            var input = new Person { FirstName = "John", LastName = "Doe" };
            var mapperConfig = new MappingConfiguration<Person, Employee>()
                .AggregateProperty(employee => employee.Info.Display, person => person.FirstName + " " + person.LastName);

            input.TestMapper<Person, Employee>((person, employee) => employee.Info != null &&
                employee.Info.Display == person.FirstName + " " + person.LastName, "Aggregate_mapping", mapperConfig);
        }

        [Test]
        public void Ignore_mapping_skips_property_from_being_mapped()
        {
            Assert.Inconclusive();
            var input = new Person { 
                FirstName = "John", 
                LastName = "Doe", 
                Id = 5.Random(from: 1), 
                Info = new PersonInfo
                {
                    BirthDate = DateTime.Today
                }};
            var mapperConfig = new MappingConfiguration<Person, Employee>()
                .Ignore(employee => employee.Id)
                .Ignore(employee => employee.Info);

            input.TestMapper((person, employee) =>
                employee != null &&
                employee.FirstName == input.FirstName &&
                employee.LastName == input.LastName &&
                employee.Info == null &&
                employee.Id == 0, "Ignore_mapping_skips_property_from_being_mapped", mapperConfig);
        }

        [Test]
        public void Nested_mapping()
        {
            Assert.Inconclusive();
            var input = new Person { FirstName = "John", LastName = "Doe", Id = 5.Random(from: 1) };
            var nestedMapper = new MappingConfiguration<PersonInfo, EmployeeInfo>()
                .ForProperty(ei => ei.BirthDate, pi => pi.BirthDate.ToShortDateString())
                .ForProperty(ei => ei.RegisteredDate, pi => pi.RegisteredDate.ToShortDateString() + " " + pi.RegisteredDate.ToShortTimeString());
            var mapperConfig = new MappingConfiguration<Person, Employee>()
                .Using(nestedMapper);

            input.TestMapper<Person, Employee>((person, employee) => employee.Info != null && 
                employee.Info.BirthDate == person.Info.BirthDate.ToShortDateString() &&
                employee.Info.RegisteredDate == person.Info.RegisteredDate.ToShortDateString() + " " + person.Info.RegisteredDate.ToShortTimeString(), 
                "Nested_mapping", mapperConfig);
        }

    }
}