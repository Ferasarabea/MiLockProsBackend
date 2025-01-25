namespace MiLockProsBackend.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }  // Password hashing is recommended for security.
        public decimal WeeklyProfit { get; set; }
    }
}
