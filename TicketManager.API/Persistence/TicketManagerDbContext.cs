using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TicketManager.Domain.Models;

namespace TicketManager.API.Persistence
{
    public class TicketManagerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TicketManagerDbContext(IConfiguration config)
        {
            _configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Attachments)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            //TODO: next step: dev & cust migration config
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Application> Applications { get; set; }


    }
}
