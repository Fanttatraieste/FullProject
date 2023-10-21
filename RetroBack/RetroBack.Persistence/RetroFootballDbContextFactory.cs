using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RetroBack.Persistence;


namespace AiWidget.Persistence
{
    public class RetroFootballDbContextFactory : IDesignTimeDbContextFactory<RetroFootballDbContext>
    {
        public RetroFootballDbContextFactory CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RetroFootballDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=CareerManagement;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;Application Name=CareerManagement;");

            return new RetroFootballDbContext(optionsBuilder.Options);
        }

      
    }
}
