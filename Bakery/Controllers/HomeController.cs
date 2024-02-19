using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;

namespace Bakery.Controllers;

public class HomeController : Controller
{
    private readonly BakeryContext _db;

    public HomeController(BakeryContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        return View();
    }
}
