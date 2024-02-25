using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bakery.Models;

namespace Bakery.ViewModels
{
  public class HomeIndexViewModel
  {
    public IEnumerable<Flavor> Flavors { get; set; }
    public IEnumerable<Treat> Treats { get; set; }
  }

}