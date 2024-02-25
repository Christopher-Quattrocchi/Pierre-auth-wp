using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Bakery.ViewModels;

namespace Bakery.Controllers;

public class HomeController : Controller
{
    private readonly BakeryContext _db;

    public HomeController(BakeryContext db)
    {
        _db = db;
    }
    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            Flavors = await _db.Flavors.ToListAsync(),
            Treats = await _db.Treats.ToListAsync()
        };
        return View(viewModel);
    }
}