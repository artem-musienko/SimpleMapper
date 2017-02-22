namespace SimpleMapper.Tests
{
    public abstract class Car
    {
        public string Make { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public abstract CarType Type { get; }
        public TransmissionType Transmission { get; set; }
    }
}