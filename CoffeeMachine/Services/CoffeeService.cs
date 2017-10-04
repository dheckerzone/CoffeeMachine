using AutoMapper;
using CoffeeMachine.ViewModel;
using EF;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine.Services
{
    public class CoffeeService: ICoffeeService
    {
        private readonly CoffeeMachineDbContext _ctx;
        private readonly IMapper _mapper;

        public CoffeeService(CoffeeMachineDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public void Add(CoffeeResource coffee)
        {
            var drinkEntity = _mapper.Map<Coffee>(coffee);
        }

        public List<CoffeeResource> GetAll()
        {
            return _mapper.Map<List<CoffeeResource>>(_ctx.Coffees);
        }

        public CoffeeResource GetByName(string name)
        {
            var drink = _ctx.Coffees.Single(d => d.Name == name);
            return _mapper.Map<CoffeeResource>(drink);
        }

        public List<CoffeeResource> RefillAll()
        {
            foreach (var d in _ctx.Coffees)
            {
                d.UnitsOfBeans = 15;
                d.UnitsOfSugar = 15;
                d.UnitsOfMilk = 15;
            }
            _ctx.SaveChanges();
            return _mapper.Map<List<CoffeeResource>>(_ctx.Coffees);
        }
    }
}
