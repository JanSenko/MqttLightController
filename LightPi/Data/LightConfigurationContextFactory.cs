using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace LightPi.Data
{
    public class LightConfigurationContextFactory : IDesignTimeDbContextFactory<LightsContext>
    {
        public LightsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LightsContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=lights;Trusted_Connection=True;");

            return new LightsContext(optionsBuilder.Options);
        }
    }
}
