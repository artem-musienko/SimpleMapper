namespace SimpleMapper.Tests
{
    public class CarViewModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Transmission { get; set; }
        public string Seats { get; set; }

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2}/{3}/{4}", Make, Model, Type, Transmission, Seats);
        }
    }
}