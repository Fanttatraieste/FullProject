using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RetroBack.Domain.Entities;



namespace RetroBack.Persistence
{
    public class RetroFootballDbContext : IdentityDbContext<ApplicationUser, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public RetroFootballDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            ConfigureIdentity(builder);
        }

        private void ConfigureIdentity(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasMany(a => a.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(a => a.UserId);

            builder.Entity<Role>().HasMany(a => a.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(a => a.RoleId);
        }
    }
}
