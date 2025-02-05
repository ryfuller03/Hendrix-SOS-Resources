namespace SOSResources.Models
{
    public class Request
    {
        public int Id { get; set; }
        public bool NeedWithin24Hours { get; set; }
        public string RequestedResource { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}