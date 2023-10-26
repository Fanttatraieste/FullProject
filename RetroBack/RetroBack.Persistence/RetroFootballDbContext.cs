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
        public DbSet<TeamUEFACup> UefaCups { get; set; }
        public DbSet<TeamUefaSuperCup> UefaSuperCups { get; set; }
        public DbSet<TeamUefaWinnersCup> UefaWinnersCups { get; set; }

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

            // ----------      UEFA Cup Builder        ---------- // 

            builder.Entity<TeamUEFACup>()
                .HasKey(u => u.UEFACupID);

            builder.Entity<TeamUEFACup>()
                .HasOne(u => u.WinnerTeam)
                .WithMany(t => t.UefaCups)
                .HasForeignKey(u => u.UefaCupWinnerId)
                .HasConstraintName("FK_UEFACupWinner_Team")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TeamUEFACup>()
                .HasOne(u => u.RunnerUpTeam)
                .WithMany(t => t.UefaCupsRunnerUps)
                .HasForeignKey(u => u.UefaCupRunnerUpId)
                .HasConstraintName("FK_UEFACupRunnerUp_Team")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      UEFA Super Cup Builder        ---------- // 

            builder.Entity<TeamUefaSuperCup>()
                .HasKey(s => s.UEFASuperCupID);

            builder.Entity<TeamUefaSuperCup>()
                .HasOne(s => s.WinnerTeam)
                .WithMany(t => t.UefaSuperCups)
                .HasForeignKey(s => s.UefaSuperCupWinnerId)
                .HasConstraintName("FK_UEFASuperCupRunnerUp_Team")  // Atentie :)))
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      UEFA Winners Cup Builder        ---------- // 

            builder.Entity<TeamUefaWinnersCup>()
                .HasKey(u => u.WinnersCupID);

            builder.Entity<TeamUefaWinnersCup>()
                .HasOne(u =>u.WinnerTeam)
                .WithMany(t => t.UefaWinnersCups)
                .HasForeignKey(u => u.UefaWinnersCupWinnerId)
                .HasConstraintName("FK_UEFAWinnerCupWinner_Team")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TeamUefaWinnersCup>()
                .HasOne(u => u.RunnerUpTeam)
                .WithMany(t => t.UefaWinnersCupRunnerUps)
                .HasForeignKey(u => u.UefaWinnersCupRunnerUpId)
                .HasConstraintName("FK_UEFAWinnerCupRunnerUp_Team")
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
