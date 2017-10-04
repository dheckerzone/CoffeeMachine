using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CoffeeMachine.ViewModel;
using EF;
using AutoMapper;

namespace CoffeeMachine.Services
{
    public class OfficePantryService : IOfficePantryService
    {
        private readonly CoffeeMachineDbContext _ctx;
        private readonly IMapper _mapper;

        public OfficePantryService(CoffeeMachineDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public OfficePantryResource Add()
        {
            throw new NotImplementedException();
        }

        List<OfficePantryResource> IOfficePantryService.GetAll()
        {
           return _mapper.Map<List<OfficePantryResource>>(_ctx.Pantries.Include(p => p.Office).ToList());
        }
    }
}
