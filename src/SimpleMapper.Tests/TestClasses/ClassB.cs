namespace SimpleMapper.Tests
{
    public class ClassB : ClassA
    {
        public new ClassC Child { get; set; }
        public override string ToString()
        {
            return string.Format("{{ Name = '{0}',  Child =  {1} }}", Name, Child == null ? "null" : Child.ToString());
        }
    }
}