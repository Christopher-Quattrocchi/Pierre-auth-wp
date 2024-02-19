using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authorization;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using System.Linq;
using System.Security.Claims;
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
      _userManager = userManager;
      _db = db;
    }
  }

}