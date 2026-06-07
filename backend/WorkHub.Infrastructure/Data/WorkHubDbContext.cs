using Microsoft.EntityFrameworkCore;
using WorkHub.Domain.Entities;

namespace WorkHub.Infrastructure.Data
{
    public sealed class WorkHubDbContext : DbContext
    {
        public WorkHubDbContext(DbContextOptions<WorkHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<Comment> Comments => Set<Comment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
                builder.Property(x => x.Description).HasMaxLength(2000);
                builder.Property(x => x.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<TaskItem>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
                builder.Property(x => x.Status).IsRequired().HasMaxLength(50);
                builder.Property(x => x.CreatedAt).IsRequired();
                builder.HasOne(x => x.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Comment>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Content).IsRequired().HasMaxLength(2000);
                builder.Property(x => x.CreatedAt).IsRequired();
                builder.HasOne(x => x.Task)
                    .WithMany(t => t.Comments)
                    .HasForeignKey(x => x.TaskId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
