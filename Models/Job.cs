namespace MiLockProsBackend.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }  // Active, Completed, Canceled
        public string? PriorityLevel { get; set; }  // Urgent, High, Medium, Low
        public decimal JobAmount { get; set; }
        public int TechnicianId { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
