using rema.Models;

namespace rema.Data.Seeds;

class EstateUnits
{
    private readonly RemaContext _context;

    public EstateUnits(RemaContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        if (_context.EstateUnits.Any())
        {
            return;
        }

        var estateUnits = new EstateUnit[]
        {
            new EstateUnit { Name = "EstateUnit1", RealEstate = findRealEstate(1) },
            new EstateUnit { Name = "EstateUnit2", RealEstate = findRealEstate(1) },
            new EstateUnit { Name = "EstateUnit3", RealEstate = findRealEstate(1) },
            new EstateUnit { Name = "EstateUnit4", RealEstate = findRealEstate(2) },
            new EstateUnit { Name = "EstateUnit5", RealEstate = findRealEstate(2) },
            new EstateUnit { Name = "EstateUnit6", RealEstate = findRealEstate(3) }
        };

        _context.AddRange(estateUnits);

        _context.SaveChanges();
    }

    private RealEstate findRealEstate(int realEstateID)
    {
        return _context.RealEstates.Find(realEstateID);
    }
}