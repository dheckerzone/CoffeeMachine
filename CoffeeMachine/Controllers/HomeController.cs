using CoffeeMachine.Services;
using CoffeeMachine.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoffeeMachine.Controllers
{
  [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ICoffeeService _coffeeSvc;
        private readonly IOfficePantryService _officePantrySvc;

        public HomeController(ICoffeeService coffeeService, IOfficePantryService ofcPantrySvc)
        {
            _coffeeSvc = coffeeService;
            _officePantrySvc = ofcPantrySvc;
        }

        [HttpGet]
        public IActionResult Get(OrderResource order)
        {
            OrderResource model = new OrderResource();

            model.CoffeeList = _coffeeSvc.GetAll();

            model.OfficePantryList = _officePantrySvc.GetAll().OrderBy(o=> o.Pantry).ToList();

            if (!string.IsNullOrEmpty(order.SelectedOfficePantry.Pantry))
            {
                model.SelectedOfficePantry = model.OfficePantryList.SingleOrDefault(o => o.Pantry == order.SelectedOfficePantry.Pantry);

                model.SuppliesAndCoffeeResource.SelectedPantry = model.OfficePantryList.SingleOrDefault(o => o.Pantry == order.SelectedOfficePantry.Pantry);
            }

            return new ObjectResult(model);
        }
    }
}
