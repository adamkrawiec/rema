using System.ComponentModel.DataAnnotations;

namespace rema.Models;

public class EstateUnit
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public RealEstate RealEstate { get; set; }
}