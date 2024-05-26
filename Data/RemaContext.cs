using rema.Models;
using Microsoft.EntityFrameworkCore;

namespace rema.Data
{
    public class RemaContext : DbContext
    {
        public RemaContext(DbContextOptions<RemaContext> options) : base(options)
        {
        }

        public DbSet<RealEstate> RealEstates { get; set; } = null;
        public DbSet<EstateUnit> EstateUnits { get; set; } = null;
    }
}