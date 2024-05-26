using rema.Data.Seeds;

namespace rema.Data;

class Seeder
{
    private readonly RemaContext _context;

    public Seeder(RemaContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        _context.Database.EnsureCreated();

        var realEstates = new RealEstates(_context);
        realEstates.Initialize();

        var estateUnits = new EstateUnits(_context);
        estateUnits.Initialize();
    }
}