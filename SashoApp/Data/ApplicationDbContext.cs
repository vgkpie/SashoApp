using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SashoApp.Models;
using SashoApp.Models.Cars;  // Добави този namespace, ако използваш моделите за коли

namespace SashoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  // Наследява от IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } // Връзка с колите

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Configure Identity tables for MySQL compatibility
    modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<string>>(entity =>
    {
        entity.Property(m => m.LoginProvider).HasColumnType("varchar(128)").HasMaxLength(128);
        entity.Property(m => m.ProviderKey).HasColumnType("varchar(128)").HasMaxLength(128);
    });

    modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserToken<string>>(entity =>
    {
        entity.Property(m => m.LoginProvider).HasColumnType("varchar(128)").HasMaxLength(128);
        entity.Property(m => m.Name).HasColumnType("varchar(128)").HasMaxLength(128);
    });

    modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>(entity =>
    {
        entity.Property(m => m.Name).HasColumnType("varchar(256)").HasMaxLength(256);
        entity.Property(m => m.NormalizedName).HasColumnType("varchar(256)").HasMaxLength(256);
        entity.Property(m => m.ConcurrencyStamp).HasColumnType("text");
    });

    modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>>(entity =>
    {
        entity.Property(m => m.ClaimType).HasColumnType("text");
        entity.Property(m => m.ClaimValue).HasColumnType("text");
    });

    modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>>(entity =>
    {
        entity.Property(m => m.ClaimType).HasColumnType("text");
        entity.Property(m => m.ClaimValue).HasColumnType("text");
    });

    modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUser>(entity =>
    {
        entity.Property(m => m.UserName).HasColumnType("varchar(256)").HasMaxLength(256);
        entity.Property(m => m.NormalizedUserName).HasColumnType("varchar(256)").HasMaxLength(256);
        entity.Property(m => m.Email).HasColumnType("varchar(256)").HasMaxLength(256);
        entity.Property(m => m.NormalizedEmail).HasColumnType("varchar(256)").HasMaxLength(256);
        entity.Property(m => m.ConcurrencyStamp).HasColumnType("text");
        entity.Property(m => m.SecurityStamp).HasColumnType("text");
        entity.Property(m => m.PhoneNumber).HasColumnType("varchar(15)").HasMaxLength(15);
    });
}


    }
}
