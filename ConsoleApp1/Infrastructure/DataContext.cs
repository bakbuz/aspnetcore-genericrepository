using ConsoleApp1.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable(nameof(Category));
                entity.HasKey(t => t.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100).IsUnicode(true);
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable(nameof(Note));
                entity.HasKey(t => t.Id);
                entity.Property(p => p.Title).IsRequired().HasMaxLength(100).IsUnicode(true);
                entity.Property(p => p.Body).IsRequired().HasMaxLength(1000).IsUnicode(true);
                entity.Property(p => p.CreatedAt).IsRequired();
            });
        }
    }
}
