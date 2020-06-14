using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAM.Data.Domain.Models;
using RAM.Data.Shared;

namespace RAM.Infrastructure.Data
{
    public class RAMDbContext : DbContext
    {
        public RAMDbContext(DbContextOptions<RAMDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApiUser>(ConfigureUser);
            builder.Entity<ApiUser>().Property(p => p.UserName).HasMaxLength(20).IsRequired(true);
            builder.Entity<ApiUser>().Property(p => p.FirstName).HasMaxLength(30).IsRequired(true);
            builder.Entity<ApiUser>().Property(p => p.LastName).HasMaxLength(30).IsRequired(true);
            builder.Entity<ApiUser>().HasKey(p => p.Id);
        }

        public void ConfigureUser(EntityTypeBuilder<ApiUser> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(ApiUser.RefreshTokens));
            //EF access the RefreshTokens collection property through its backing field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Ignore(b => b.PasswordHash);
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ApiUser> RAMUsers { get; set; }
        public DbSet<Memory> Memories { get; set; }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
