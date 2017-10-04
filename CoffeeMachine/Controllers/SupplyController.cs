using CoffeeMachine.Services;
using CoffeeMachine.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Controllers
{
  [Route("api/[controller]")]
  public class SupplyController : Controller
  {
    private readonly ISupplyService _supplySvc;

    public SupplyController(ISupplyService supplySvc)
    {
      _supplySvc = supplySvc;
    }

    [HttpGet("{pantry}")]
    public IActionResult Get(string pantry)
    {
      return new ObjectResult(_supplySvc.Get(pantry));
    }

    [Route("RefillSupplies")]
    [HttpPut]
    public IActionResult RefillSupplies([FromBody] SaveOrderResource pantry)
    {
      var result = _supplySvc.Refill(pantry.PantryId.ToString());
      return new ObjectResult(result);
    }
  }

}
