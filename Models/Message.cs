namespace MiLockProsBackend.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int JobId { get; set; }
        public string? Sender { get; set; }  // Sender can be Technician or Manager
        public string? Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
