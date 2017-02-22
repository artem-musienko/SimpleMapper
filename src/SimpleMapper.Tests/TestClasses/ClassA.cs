namespace SimpleMapper.Tests
{
    public class ClassA
    {
        public string Name { get; set; }
        public ClassB Child { get; set; }
        public override string ToString()
        {
            return string.Format("{{ Name = '{0}',  Child =  {1} }}", Name, Child == null ? "null" : Child.ToString());
        }
    }
}