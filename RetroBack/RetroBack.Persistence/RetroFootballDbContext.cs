using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RetroBack.Domain.Entities;
using FootballIconsCAPI.Entities;

namespace RetroBack.Persistence
{
    public class RetroFootballDbContext : IdentityDbContext<ApplicationUser, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<ChampionsCup> ChampionsCups { get; set; }
        public DbSet<TeamDomesticCup> DomesticCups { get; set; }
        public DbSet<TeamDomesticLeague> DomesticLeagues { get; set; }
        public DbSet<TeamDomesticSuperCup> DomesticSuperCups { get; set; }

        public RetroFootballDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>().Property(t => t.TeamName).IsRequired();
            builder.Entity<Team>().Property(t => t.TeamCountry).IsRequired();

            // ----------      Champions Cup Builder        ---------- // 
            builder.Entity<ChampionsCup>()
                .HasOne(c => c.Winner)
                .WithMany(t => t.ChampionsCups)
                .HasForeignKey(c => c.WinnerTeamId)
                .HasConstraintName("FK_ChampionsCup_Team")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ChampionsCup>()
                .HasOne(c => c.RunnerUp)
                .WithMany(t => t.ChampionsCupRunnerUps)
                .HasForeignKey(c => c.RunnerUpTeamId)
                .HasConstraintName("FK_ChampionsCupRunnerUps_Team")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Domestic Cup Builder        ---------- // 

            builder.Entity<TeamDomesticCup>()
                .HasKey(t => t.DomesticCupID);

            builder.Entity<TeamDomesticCup>()
                .HasOne(c => c.WinnerTeam)
                .WithMany(t => t.DomesticCups)
                .HasForeignKey(c => c.WinnerId)
                .HasConstraintName("FK_DomesticCup_Team")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Domestic League Builder        ---------- // 

            builder.Entity<TeamDomesticLeague>()
                .HasKey(t => t.DomesticLeagueID);

            builder.Entity<TeamDomesticLeague>()
                .HasOne(l => l.WinnerTeam)
                .WithMany(t => t.DomesticLeagues)
                .HasForeignKey(l => l.WinnerId)
                .HasConstraintName("FK_DomesticLeagueWinner_Team")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TeamDomesticLeague>()
                .HasOne(l => l.RunnerUpTeam)
                .WithMany(t => t.DomesticLeagueRunnerUps)
                .HasForeignKey(l => l.RunnerUpId)
                .HasConstraintName("FK_DomesticLeagueRunnerUp_Team")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Domestic Super Cup Builder        ---------- // 

            builder.Entity<TeamDomesticSuperCup>()
                .HasKey(s => s.DomesticSuperCupID);

            builder.Entity<TeamDomesticSuperCup>()
                .HasOne(s => s.Winner)
                .WithMany(t => t.DomesticSuperCups)
                .HasForeignKey(s => s.WinnerId)
                .HasConstraintName("FK_DomesticSuperCupWinner_Team")
                .OnDelete(DeleteBehavior.NoAction);

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
