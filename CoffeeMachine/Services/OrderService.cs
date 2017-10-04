using AutoMapper;
using CoffeeMachine.ViewModel;
using EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoffeeMachine.Services
{
  public class OrderService : IOrderService
  {
    private readonly CoffeeMachineDbContext _ctx;
    private readonly IMapper _mapper;
    private readonly ISupplyService _supplySvc;

    public OrderService(CoffeeMachineDbContext context, IMapper mapper, ISupplyService supplySvc)
    {
      _ctx = context;
      _mapper = mapper;
      _supplySvc = supplySvc;
    }

    public List<OrderHistoryResource> GetOrderHistory()
    {
      var result = _mapper.Map<List<OrderHistoryResource>>(
        _ctx
        .Orders
        .Include(p=> p.Pantry)
        .Include(o=> o.Pantry.Office)
        .Include(c=> c.Coffee)
        .OrderByDescending(o=> o.OrderDate));
      return result;
    }

    public void Save(SaveOrderResource order)
    {
      var coffee = _ctx.Coffees.SingleOrDefault(c => c.Id == order.CoffeeId);

      var pantry = _ctx.Pantries.SingleOrDefault(p => p.Id == order.PantryId);

      _ctx.Orders.Add(new Order
      {
        Id = Guid.NewGuid(),
        OrderDate = DateTime.Now,
        CoffeeId = coffee.Id,
        Coffee = coffee,
        PantryId = pantry.Id,
        Pantry = pantry,
      });

      _ctx.SaveChanges();

      _supplySvc.Update(order);
    }
  }
}
