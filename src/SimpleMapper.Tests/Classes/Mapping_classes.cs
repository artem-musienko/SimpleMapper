using System;
using System.Globalization;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    public partial class Mapping_classes
    {

        [Test]
        public void Map_class_with_builtin_typed_properties_to_another()
        {
            var testUser = new EmployeeData
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Salary = 100.5,
                    Age = 50.Random(20),
                    Registered = DateTime.Today.AddYears(-1 * 5.Random()),
                    Nickname = "Jondo"
                };
            testUser.TestMapper<EmployeeData, Employee>((data, employee) =>
                employee != null && data.FirstName == employee.FirstName && data.LastName == employee.LastName &&
                data.Registered.ToString(CultureInfo.CurrentCulture) == employee.Registered && (decimal)data.Salary == employee.Salary, "Simple class mapping");
        }

        [Test]
        public void Map_class_with_custom_typed_property_to_another()
        {
            var node = new Node { Name = "Root", Child = new Node { Name = "Child 1", Child = new Node { Name = "Child 2" } } };
            node.TestMapper<Node, Tree>((n, root) => n.ToString() == root.ToString(),
                "Nested mapping");
        }

        [Test]
        public void Map_class_with_nested_properties_to_treelike_structure()
        {
            var input = new ClassA
                {
                    Name = "I'm A",
                    Child = new ClassB
                        {
                            Name = "I'm B",
                            Child = new ClassC
                                {
                                    Name = "I'm C",
                                    Child = new ClassD
                                        {
                                            Name = "I'm D",
                                            Child = new ClassB
                                                {
                                                    Name = "I'm B and have no child"
                                                }
                                        }
                                }
                        }
                };            
            input.TestMapper<ClassA, Node>((a, node) => a.ToString() == node.ToString(), "Loop nested mapping");
        }

        [Test]
        public void Map_child_class()
        {
            var myCar = new Minivan
                {
                    Make = "Ferrari",
                    Model = "Unknown",
                    Transmission = TransmissionType.Manual,
                    Year = DateTime.Today.Year,
                    Seats = 10
                };
            myCar.TestMapper<Minivan, CarViewModel>((car, model) => car.ToString() == model.ToString(), "Inheritance mapping");
        }
    }
}