using Assesment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Taskk> Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taskk>()
                .HasOne(x => x.project)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ProjectIDD)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Taskk>()
               .HasOne(x => x.teammember)
               .WithMany(x => x.Tasks)
               .HasForeignKey(x => x.Teammemberidd)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
