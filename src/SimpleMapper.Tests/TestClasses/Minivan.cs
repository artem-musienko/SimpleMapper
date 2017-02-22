namespace SimpleMapper.Tests
{
    public class Minivan : Car
    {
        public override CarType Type
        {
            get { return CarType.Minivan; }
        }

        public int Seats { get; set; }

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2}/{3}/{4}", Make, Model, Type, Transmission, Seats);
        }
    }
}