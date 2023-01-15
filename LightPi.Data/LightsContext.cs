using LightPi.Shared;
using Microsoft.EntityFrameworkCore;

namespace LightPi.Data
{
    public class LightsContext : DbContext
    {
        public LightsContext(DbContextOptions<LightsContext> options) : base(options) { }
        public virtual DbSet<Light> Lights { get; set; }
    }
}
