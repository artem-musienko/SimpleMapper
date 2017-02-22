namespace SimpleMapper.Tests
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public byte Age { get; set; }
        public string Registered { get; set; }

        public string FullName { get; set; }
        public EmployeeInfo Info { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}, age: {2} registered: {3}, salary: ${4:0.00}",
                FirstName, LastName, Age, Registered ?? "<null>", Salary);
        }
    }
}