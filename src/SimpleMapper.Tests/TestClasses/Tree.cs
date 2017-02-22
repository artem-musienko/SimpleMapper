namespace SimpleMapper.Tests
{
    public class Tree
    {
        public string Name { get; set; }
        public Tree Child { get; set; }

        public override string ToString()
        {
            return string.Format("{{ Name = '{0}',  Child =  {1} }}", Name, Child == null ? "null" : Child.ToString());
        }
    }
}