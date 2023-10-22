using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RetroBack.Persistence;


namespace AiWidget.Persistence
{
    public class RetroFootballDbContextFactory : IDesignTimeDbContextFactory<RetroFootballDbContext>
    {
        public RetroFootballDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RetroFootballDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=RetroFootball;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;Application Name=RetroFootball;");

            return new RetroFootballDbContext(optionsBuilder.Options);
        }

    }
}
