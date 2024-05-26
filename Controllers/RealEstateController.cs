using Microsoft.AspNetCore.Mvc;
using rema.Models;
using rema.Data;
using Microsoft.EntityFrameworkCore;

namespace rema.Controllers;

[Route("real-estates")]
public class RealEstateController : Controller
{
    private readonly RemaContext _context;

    public RealEstateController(RemaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var realEstates = await _context.RealEstates.ToListAsync();
        return View(realEstates);
    }

    [HttpGet("new")]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name")] RealEstate realEstate)
    {
        if (ModelState.IsValid)
        {
            _context.Add(realEstate);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View("New");
    }

    [Route("{id}")]
    public async Task<IActionResult> Show(int id)
    {
        var realEstate = await _context.RealEstates.Include(re => re.EstateUnits).AsNoTracking().FirstOrDefaultAsync(re => re.Id == id);

        if (realEstate == null)
        {
            return NotFound();
        }
        return View(realEstate);
    }
}
