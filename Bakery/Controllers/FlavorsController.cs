using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace Bakery.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly BakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public FlavorsController(BakeryContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
      return View(await _db.Flavors.ToListAsync());

    }

    public IActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Flavor flavor)
    {
      if (ModelState.IsValid)
      {
        _db.Flavors.Add(flavor);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(flavor);
    }

    public async Task<IActionResult> Edit(int id)
    {
      Flavor flavor = await _db.Flavors.FindAsync(id);
      if (flavor == null)
      {
        return NotFound();
      }
      return View(flavor);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Flavor flavor)
    {
      if (ModelState.IsValid)
      {
        _db.Update(flavor);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(flavor);
    }

    public async Task<IActionResult> Details(int id)
    {
      Flavor flavor = await _db.Flavors
          .Include(f => f.JoinEntities)
          .ThenInclude(fj => fj.Treat)
          .FirstOrDefaultAsync(f => f.FlavorId == id);

      if (flavor == null)
      {
        return NotFound();
      }

      return View(flavor);
    }

    public async Task<IActionResult> Delete(int id)
    {
      Flavor flavor = await _db.Flavors.FindAsync(id);
      if (flavor != null)
      {
        _db.Flavors.Remove(flavor);
        await _db.SaveChangesAsync();
      }
      return RedirectToAction("Index");
    }

   
    public ActionResult AddTreat(int flavorId)
    {

      Flavor flavor = _db.Flavors.FirstOrDefault(Flavor => Flavor.FlavorId == flavorId);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(flavor);
    }

    
    [HttpPost]
    public async Task<IActionResult> AddTreat(int flavorId, int treatId)
    {
      if (treatId == 0)
      {
        return RedirectToAction("Details", new { id = flavorId });
      }

      var existingAssociation = await _db.FlavorTreats
          .AnyAsync(ft => ft.TreatId == treatId && ft.FlavorId == flavorId);

      if (!existingAssociation)
      {
        _db.FlavorTreats.Add(new FlavorTreat { TreatId = treatId, FlavorId = flavorId });
        await _db.SaveChangesAsync();
      }

      return RedirectToAction("Details", new { id = flavorId });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteTreat(int flavorId, int treatId)
    {
      FlavorTreat flavorTreat = await _db.FlavorTreats
          .FirstOrDefaultAsync(ft => ft.FlavorId == flavorId && ft.TreatId == treatId);
      if (flavorTreat != null)
      {
        _db.FlavorTreats.Remove(flavorTreat);
        await _db.SaveChangesAsync();
      }
      return RedirectToAction("Index");
    }
  }

}