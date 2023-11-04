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
        public DbSet<Nation> Nations { get; set; }
        public DbSet<NationWorldCup> WorldCups { get; set; }
        public DbSet<NationContinentalCup> ContinentalCups { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<WorldCupSquads> WorldCupSquads { get; set; }
        public DbSet<NationIconStats> NationIconStats { get; set; }
        public DbSet<NationIconStatsWorldCupSquads> NationIconStatsWorldCupSquads { get; set; }
        public DbSet<ContinentalCupSquads> ContinentalCupSquads { get; set; }
        public DbSet<NationIconStatsContinentalCupSquads> NationIconStatsContinentalCupSquads { get; set; }
        public DbSet<TeamIconStats> TeamIconStats { get; set; }
        public DbSet<BallonDor> BallonDors { get; set; }
        public DbSet<BallonDorStats> BallonDorStats { get; set; }
        public DbSet<BallonDorNominationsStats> BallonDorNominationsStats { get; set; }

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

            // ----------      Nations Builder        ---------- // 

            builder.Entity<Nation>()
                .HasKey(n => n.NationID);

            // ----------      World Cup Builder        ---------- // 

            builder.Entity<NationWorldCup>()
                .HasKey(w => w.WorldCupID);

            builder.Entity<NationWorldCup>()
                .HasOne(w => w.WinnerNation)
                .WithMany(n => n.WorldCups)
                .HasForeignKey(w => w.WinnerNationId)
                .HasConstraintName("FK_WorldCupWinner_Nation")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<NationWorldCup>()
                .HasOne(w => w.RunnerUpNation)
                .WithMany(n => n.WorldCupRunnerUps)
                .HasForeignKey(w => w.RunnerUpNationId)
                .HasConstraintName("FK_WorldCupRunnerUp_Nation")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<NationWorldCup>()
                .HasOne(w => w.ThirdPlaceNation)
                .WithMany(n => n.WorldCupThirdPlaces)
                .HasForeignKey(w => w.ThirdPlaceNationId)
                .HasConstraintName("FK_WorldCupThirdPlace_Nation")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Continental Cup Builder        ---------- // 

            builder.Entity<NationContinentalCup>()
                .HasKey(c => c.ContinentalCupID);

            builder.Entity<NationContinentalCup>()
                .HasOne(c => c.WinnerNation)
                .WithMany(n => n.ContinentalCups)
                .HasForeignKey(c => c.WinnerNationId)
                .HasConstraintName("FK_ContinentalCupWinner_Nation")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<NationContinentalCup>()
                .HasOne(c => c.RunnerUpNation)
                .WithMany(n => n.ContinentalCupRunnerUps)
                .HasForeignKey(c => c.RunnerUpNationId)
                .HasConstraintName("FK_ContinentalCupRunnerUp_Nation")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<NationContinentalCup>()
                .HasOne(c => c.ThirdPlaceNation)
                .WithMany(n => n.ContinentalCupThirdPlaces)
                .HasForeignKey(c => c.ThirdPlaceNationId)
                .HasConstraintName("FK_ContinentalCupThirdPlace_Nation")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Icon Builder        ---------- // 

            builder.Entity<Icon>()
                .HasKey(i => i.IconId);

            builder.Entity<Icon>()
                .Property(i => i.FirstName).IsRequired().HasMaxLength(450);

            builder.Entity<Icon>()
                .Property(i => i.LastName).IsRequired().HasMaxLength(450);

            // ----------      Nation Icon Stats Builder        ---------- // 

            builder.Entity<NationIconStats>()
                .HasKey(s => s.StatId);

            builder.Entity<NationIconStats>()
                .HasOne(s => s.Icon)
                .WithOne(i => i.NationIconStats)
                .HasConstraintName("FK_NationStats_Icon")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<NationIconStats>()
                .HasOne(s => s.Nation)
                .WithMany(n => n.IconsStats)
                .HasForeignKey(s => s.NationId)
                .HasConstraintName("FK_NationStats_Nation")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Nation Icon Stats <--- Middle Table ---> World Cup Squads Builder for Middle Table       ---------- // 
            builder.Entity<NationIconStatsWorldCupSquads>()
                .HasKey(n => new { n.StatsId, n.SquadId });
                

            builder.Entity<NationIconStatsWorldCupSquads>()
                .HasOne(n => n.NationIconStats)
                .WithMany(s => s.WorldCupSquads)
                .HasForeignKey(n => n.StatsId)
                .HasConstraintName("FK_ManyToMany_NationStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<NationIconStatsWorldCupSquads>()
                .HasOne(n => n.WorldCupSquads)
                .WithMany(w => w.Players)
                .HasForeignKey(n => n.SquadId)
                .HasConstraintName("FK_ManyToMany_WorldCupSquads")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      World Cup Squads Builder        ---------- // 

            builder.Entity<WorldCupSquads>()
                .HasKey(c => c.SquadId);

            builder.Entity<WorldCupSquads>()
                .HasOne(s => s.Nation)
                .WithMany(n => n.WorldCupSquads)
                .HasForeignKey(s => s.NationId)
                .HasConstraintName("FK_WorldCupSquad_Nation")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Nation Icon Stats <--- Middle Table ---> Continental Cup Squads Builder for Middle Table       ---------- // 

            builder.Entity<NationIconStatsContinentalCupSquads>()
                .HasKey(n => new { n.SquadId, n.StatsId });

            builder.Entity<NationIconStatsContinentalCupSquads>()
                .HasOne(s => s.NationIconStats)
                .WithMany(n => n.ContinentalCupSquads)
                .HasForeignKey(s => s.StatsId)
                .HasConstraintName("FK_ManyToMany_NationIconStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<NationIconStatsContinentalCupSquads>()
                .HasOne(s => s.ContinentalCupSquads)
                .WithMany(n => n.Players)
                .HasForeignKey(s => s.SquadId)
                .HasConstraintName("FK_ManyToMany_ContinentalCupSquads")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Continental Cup Squads Builder        ---------- // 

            builder.Entity<ContinentalCupSquads>()
                .HasKey(c => c.SquadId);

            builder.Entity<ContinentalCupSquads>()
                .HasOne(s => s.Nation)
                .WithMany(n => n.ContinentalCupSquads)
                .HasForeignKey(s => s.NationId)
                .HasConstraintName("FK_ContinentalCupSquad_Nation")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Team Stats Builder        ---------- // 

            builder.Entity<TeamIconStats>()
                .HasKey (c => c.StatId);

            builder.Entity<TeamIconStats>()
                .HasOne(s => s.Icon)
                .WithMany(i => i.TeamIconStats)
                .HasForeignKey(s => s.IconId)
                .HasConstraintName("FK_IconStat_Icon")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TeamIconStats>() 
                .HasOne(s => s.Team)
                .WithMany(t => t.IconStats)
                .HasForeignKey(s => s.TeamId)
                .HasConstraintName("FK_IconStats_Team")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Ballon Dor Stats Builder        ---------- // 

            builder.Entity<BallonDorStats>()
                .HasKey(b => b.StatId);

            builder.Entity<BallonDorStats>()
                .HasOne(b => b.Icon)
                .WithOne(i => i.BallonDorStats)
                .HasConstraintName("FK_BallonDorStat_Icon")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Ballon Dor Builder        ---------- // 

            builder.Entity<BallonDor>()
                .HasKey(b => b.BallonDorId);

            builder.Entity<BallonDor>()
                .HasOne(b => b.WinnerIcon)
                .WithMany(z => z.BallonDorWins)
                .HasForeignKey(b => b.WinnerIconId)
                .HasConstraintName("FK_BallonDorWinner_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDor>()
                .HasOne(b => b.RunnerUpIcon)
                .WithMany(z => z.BallonDorSeconPlaces)
                .HasForeignKey(b => b.RunnerUpIconId)
                .HasConstraintName("FK_BallonDorSecondPlace_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDor>()
                .HasOne(b => b.ThirdPlaceIcon)
                .WithMany(z => z.BallonDorThirdPlaces)
                .HasForeignKey(b => b.ThirdPlaceIconId)
                .HasConstraintName("FK_BallonDorThirdPlace_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDor>()
                .HasOne(b => b.FourthPlaceIcon)
                .WithMany(z => z.BallonDorFourthPlaces)
                .HasForeignKey(b => b.FourthPlaceIconId)
                .HasConstraintName("FK_BallonDorFourthPlace_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDor>()
                .HasOne(b => b.FifthPlaceIcon)
                .WithMany(z => z.BallonDorFifthPlaces)
                .HasForeignKey(b => b.FifthPlaceIconId)
                .HasConstraintName("FK_BallonDorFifthPlace_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDor>()
                .HasOne(b => b.SixthPlaceIcon)
                .WithMany(z => z.BallonDorSixthPlaces)
                .HasForeignKey(b => b.SixthPlaceIconId)
                .HasConstraintName("FK_BallonDorSixthPlace_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDor>()
                .HasOne(b => b.SeventhPlaceIcon)
                .WithMany(z => z.BallonDorSeventhPlaces)
                .HasForeignKey(b => b.SeventhPlaceIconId)
                .HasConstraintName("FK_BallonDorSeventhPlace_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDor>()
                .HasOne(b => b.EigthPlaceIcon)
                .WithMany(z => z.BallonDorEigthPlaces)
                .HasForeignKey(b => b.EigthPlaceIconId)
                .HasConstraintName("FK_BallonDorEigthPlace_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDor>()
                .HasOne(b => b.NinethPlaceIcon)
                .WithMany(z => z.BallonDorNinethPlaces)
                .HasForeignKey(b => b.NinethPlaceIconId)
                .HasConstraintName("FK_BallonDorNinethPlace_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDor>()
                .HasOne(b => b.TenthPlaceIcon)
                .WithMany(z => z.BallonDorTenthPlaces)
                .HasForeignKey(b => b.TenthPlaceIconId)
                .HasConstraintName("FK_BallonDorTenthPlace_BallonStats")
                .OnDelete(DeleteBehavior.NoAction);

            // ----------      Ballon Dor Nominations -> Many to Many <- BallonDor Stats Builder        ---------- // 

            builder.Entity<BallonDorNominationsStats>()
                .HasKey(b => new { b.BallonId, b.BallonStatId });

            builder.Entity<BallonDorNominationsStats>()
                .HasOne(b => b.BallonDor)
                .WithMany(d => d.Nominations)
                .HasForeignKey(b => b.BallonId)
                .HasConstraintName("FK_Nomination_BallonDor")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BallonDorNominationsStats>()
                .HasOne(b => b.BallonDorStats)
                .WithMany(d => d.BallonDorNominations)
                .HasForeignKey(b => b.BallonStatId)
                .HasConstraintName("FK_Nominations_BallonStats")
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
