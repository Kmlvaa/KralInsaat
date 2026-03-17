using KralInsaat.Common.Entities;
using KralInsaat.Common.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

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
        public DbSet<ProductEntity> Products { get; set; } 
        public DbSet<ProductImagesEntity> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
               .HasIndex(x => x.UserName)
               .IsUnique();

            modelBuilder.Entity<AppUser>()
              .HasIndex(x => x.Email)
              .IsUnique();

            ApplyGlobalFilters<IBaseEntity>(modelBuilder, e => e.DeletedAt == null);
        }

        public void ApplyGlobalFilters<TInterface>(ModelBuilder modelBuilder, Expression<Func<TInterface, bool>> expression)
        {
            var entities = modelBuilder.Model
                .GetEntityTypes()
                .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
                .Select(e => e.ClrType);

            foreach (var entity in entities)
            {
                var newParam = Expression.Parameter(entity);
                var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
                modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
            }
        }

        public override int SaveChanges()
        {
            AddEntryHistory();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddEntryHistory();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddEntryHistory()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted);

            foreach (var entry in entities)
            {
                if (entry.Entity is not IBaseEntity entity)
                    continue;

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entity.DeletedAt = DateTime.UtcNow;
                }
                
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                else
                {
                    entry.Property(nameof(IBaseEntity.CreatedAt)).IsModified = false;
                    entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
