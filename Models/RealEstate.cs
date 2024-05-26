using System.ComponentModel.DataAnnotations;

namespace rema.Models;

public class RealEstate
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<EstateUnit>? EstateUnits { get; set; }
}