using rema.Models;

namespace rema.Data;

class DBInitializer
{
    public static void Initialize(RemaContext context)
    {
        context.Database.EnsureCreated();

        if (context.RealEstates.Any())
        {
            return;
        }

        var realEstates = new RealEstate[]
        {
            new RealEstate { Name = "RealEstate1" },
            new RealEstate { Name = "RealEstate2" },
            new RealEstate { Name = "RealEstate3" }
        };
        context.AddRange(realEstates);

        context.SaveChanges();

        var estateUnits = new EstateUnit[]
        {
            new EstateUnit { Name = "EstateUnit1", RealEstate = realEstates[0] },
            new EstateUnit { Name = "EstateUnit2", RealEstate = realEstates[0] },
            new EstateUnit { Name = "EstateUnit3", RealEstate = realEstates[0] },
            new EstateUnit { Name = "EstateUnit4", RealEstate = realEstates[1] },
            new EstateUnit { Name = "EstateUnit5", RealEstate = realEstates[1] },
            new EstateUnit { Name = "EstateUnit6", RealEstate = realEstates[2] }
        };

        context.AddRange(estateUnits);

        context.SaveChanges();
    }
}