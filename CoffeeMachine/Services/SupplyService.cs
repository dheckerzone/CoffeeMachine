using AutoMapper;
using CoffeeMachine.ViewModel;
using EF;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoffeeMachine.Services
{
  public class SupplyService : ISupplyService
  {
    private readonly IMapper _mapper;
    private readonly CoffeeMachineDbContext _ctx;

    public SupplyService(CoffeeMachineDbContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    public List<SuppliesResource> Get(string pantry)
    {
      return _mapper.Map<List<SuppliesResource>>(
        _ctx
        .Supplies
        .Include(p=> p.Pantry)
        .Include(o=>o.Pantry.Office)
        .Where(p => p.Pantry.Name == pantry))
        .OrderBy(s=> s.Description)
        .ToList();
    }

    public List<SuppliesResource> Refill(string pantry)
    {
      var supplies = _ctx.Supplies.Where(p => p.PantryId.ToString() == pantry);
      foreach (var s in supplies)
      {
        s.Units = 45;
      }
      _ctx.SaveChanges();

      var pantryName = _ctx.Pantries.SingleOrDefault(p => p.Id.ToString() == pantry).Name;


      return Get(pantryName);
    }

    public void Update(SaveOrderResource order)
    {
      var selectedCoffee = _ctx.Coffees.SingleOrDefault(c => c.Id == order.CoffeeId);

      var supply = _ctx.Supplies.Where(s => s.PantryId == order.PantryId);

      supply.SingleOrDefault(s => s.Description == "Beans").Units -= selectedCoffee.UnitsOfBeans;

      supply.SingleOrDefault(s => s.Description == "Milk").Units -= selectedCoffee.UnitsOfMilk;

      supply.SingleOrDefault(s => s.Description == "Sugar").Units -= selectedCoffee.UnitsOfSugar;

      _ctx.SaveChanges();
    }
  }
}

