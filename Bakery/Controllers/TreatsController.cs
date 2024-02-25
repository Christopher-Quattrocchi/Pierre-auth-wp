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
  public class TreatsController : Controller
  {
    private readonly BakeryContext _db;

    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(BakeryContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }
    public async Task<IActionResult> Index()
    {
      return View(await _db.Treats.ToListAsync());
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Treat treat)
    {
      if (ModelState.IsValid)
      {
        _db.Treats.Add(treat);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(treat);
    }

    public async Task<IActionResult> Edit(int id)
    {
      Treat treat = await _db.Treats.FindAsync(id);
      if (treat == null)
      {
        return NotFound();
      }
      return View(treat);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Treat treat)
    {
      if (ModelState.IsValid)
      {
        _db.Update(treat);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(treat);
    }

    public async Task<IActionResult> Details(int id)
    {
      Treat treat = await _db.Treats
          .Include(t => t.JoinEntities)
          .ThenInclude(jt => jt.Flavor)
          .FirstOrDefaultAsync(t => t.TreatId == id);

      if (treat == null)
      {
        return NotFound();
      }

      return View(treat);
    }

    public async Task<IActionResult> Delete(int id)
    {
      Treat treat = await _db.Treats.FindAsync(id);
      if (treat != null)
      {
        _db.Treats.Remove(treat);
        await _db.SaveChangesAsync();
      }
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
      if (treat == null)
      {
        return NotFound();
      }
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(treat);
    }


    [HttpPost]
    public async Task<IActionResult> AddFlavor(int flavorId, int treatId)
    {
      if (flavorId == 0)
      {
        return RedirectToAction("Details", new { id = treatId });
      }

      var existingAssociation = await _db.FlavorTreats
          .AnyAsync(ft => ft.FlavorId == flavorId && ft.TreatId == treatId);

      if (!existingAssociation)
      {
        _db.FlavorTreats.Add(new FlavorTreat { TreatId = treatId, FlavorId = flavorId });
        await _db.SaveChangesAsync();
      }

      return RedirectToAction("Details", new { id = treatId });
    }


    [HttpPost]
    public async Task<IActionResult> DeleteFlavor(int flavorId, int treatId)
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
