using KralInsaat.Common.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KralInsaat.Db
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ServiceEntity> Services { get; set; } 
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<FaqEntity> Faqs { get; set; }
        public DbSet<TermsEntity> Terms { get; set; }
        public DbSet<SocialMediaAccountEntity> SocialMediaAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
               .HasIndex(x => x.UserName)
               .IsUnique();

            modelBuilder.Entity<AppUser>()
              .HasIndex(x => x.Email)
              .IsUnique();

        }
    }
}
