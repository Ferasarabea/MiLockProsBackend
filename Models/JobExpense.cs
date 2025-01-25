namespace MiLockProsBackend.Models
{
    public class JobExpense
    {
        public int ExpenseId { get; set; }  // Define this as the primary key
        public int JobId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

