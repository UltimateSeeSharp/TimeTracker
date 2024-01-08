using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace TimeTracker.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Entry to ApplicationUser relationship
            builder.Entity<Entry>()
                .HasOne(e => e.Employee)
                .WithMany(u => u.Entries)
                .HasForeignKey(e => e.EmployeeId);

            // Configure Entry to Project relationship
            builder.Entity<Entry>()
                .HasOne(e => e.Project)
                .WithMany(p => p.Entries)
                .HasForeignKey(e => e.ProjectId);
        }
    }
}