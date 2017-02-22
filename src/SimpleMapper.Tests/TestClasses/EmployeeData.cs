using System;

namespace SimpleMapper.Tests
{

    public class EmployeeData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Registered { get; set; }
        public string Nickname { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} aka {2}, {3} years old with salary {5} registered: {4:MM/dd/yyyy}",
                                 FirstName, LastName, Nickname, Age, Registered, Salary);
        }
    }
}
