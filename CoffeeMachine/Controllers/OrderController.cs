using CoffeeMachine.Services;
using CoffeeMachine.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Controllers
{
  [Route("api/[controller]")]
  public class OrderController : Controller
  {
    private readonly IOrderService _orderSvc;

    public OrderController(IOrderService orderSvc)
    {
      _orderSvc = orderSvc;
    }

    [Route("SaveOrder")]
    [HttpPost]
    public IActionResult Post([FromBody] SaveOrderResource order)
    {
      _orderSvc.Save(order);
      return Ok();
    }

    [Route("GetOrderHistory")]
    [HttpGet]
    public IActionResult GetOrderHistory()
    {
      return new ObjectResult(_orderSvc.GetOrderHistory());
    }
  }
}