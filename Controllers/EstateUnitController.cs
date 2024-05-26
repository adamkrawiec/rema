
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rema.Data;

namespace ream.Controllers;

[Route("real-estates/{realEstateId}/estate-units")]
public class EstateUnitController : Controller
{
  private readonly RemaContext _context;

  public EstateUnitController(RemaContext context)
  {
    _context = context;
  }

  public async Task<IActionResult> Index(int realEstateId)
  {
    var estateUnits = await _context.EstateUnits.ToListAsync();

    return View(estateUnits);
  }

  [HttpGet("new")]
  public IActionResult New()
  {
    return View();
  }
}