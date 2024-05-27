
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rema.Data;
using rema.Models;

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
  public IActionResult New(int realEstateId)
  {
    ViewBag.RealEstateId = realEstateId;
    return View();
  }

  [HttpPost("Create")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(int realEstateId, [Bind("Name")] EstateUnit estateUnit)
  {
      var realEstate = await _context.RealEstates.FindAsync(realEstateId);
      estateUnit.RealEstate = realEstate;
      ModelState.Clear();
      TryValidateModel(estateUnit);
    if (ModelState.IsValid)
    {
      _context.Add(estateUnit);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index", new { realEstateId });
    }
    return View("New");
  }
}