namespace SimpleMapper.Tests
{
    public class ClassC : ClassA
    {
        public new ClassD Child { get; set; }
        public override string ToString()
        {
            return string.Format("{{ Name = '{0}',  Child =  {1} }}", Name, Child == null ? "null" : Child.ToString());
        }
    }
}