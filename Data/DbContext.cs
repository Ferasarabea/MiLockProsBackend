using Microsoft.EntityFrameworkCore;
using MiLockProsBackend.Models;

namespace MiLockProsBackend.Data
{
    public class LocksmithDbContext : DbContext
    {
        public LocksmithDbContext(DbContextOptions<LocksmithDbContext> options) : base(options) { }

        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<JobExpense> JobExpenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicitly set the primary key for JobExpense
            modelBuilder.Entity<JobExpense>()
                .HasKey(e => e.ExpenseId);  // Ensure ExpenseId is recognized as the primary key

            // Optional: If needed, configure relationships or other settings here

            base.OnModelCreating(modelBuilder);
        }
    }
}

