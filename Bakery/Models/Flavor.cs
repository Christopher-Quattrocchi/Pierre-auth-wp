using System.Collections.Generic;


namespace Bakery.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    public int Name { get; set; }
    public List<FlavorTreat> JoinEntities { get; set; }
  }
}
