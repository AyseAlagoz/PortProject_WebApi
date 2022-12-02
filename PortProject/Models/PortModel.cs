namespace PortProject.Models
{
    public class PortModel
    {
        public Guid id { get; set; }
        public string portName { get; set; }
        public string portCode { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string city { get; set; }
    }
}
