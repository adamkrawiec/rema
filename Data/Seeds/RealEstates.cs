using rema.Models;

namespace rema.Data.Seeds;

class RealEstates
{
    private readonly RemaContext _context;

    public RealEstates(RemaContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        if (_context.RealEstates.Any())
        {
            return;
        }

        var realEstates = new RealEstate[]
        {
            new RealEstate { Name = "RealEstate1" },
            new RealEstate { Name = "RealEstate2" },
            new RealEstate { Name = "RealEstate3" }
        };
        _context.AddRange(realEstates);

        _context.SaveChanges();
    }
}