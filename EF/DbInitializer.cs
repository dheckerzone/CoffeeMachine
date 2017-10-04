using System;
using System.Collections.Generic;
using System.Linq;

namespace EF
{
    public class DbInitializer
    {
        private readonly CoffeeMachineDbContext _ctx;

        public DbInitializer(CoffeeMachineDbContext context)
        {
            _ctx = context;
        }

        public void Seed()
        {
            //Seed Coffee
            List<Coffee> coffees = SeedCoffee();

            if (!_ctx.Coffees.Any())
            {
                _ctx.Coffees.AddRange(coffees);
                _ctx.SaveChanges();
            }

            //Seed Office
            List<Office> offices = SeedOffice();

            if (!_ctx.Offices.Any())
            {
                _ctx.Offices.AddRange(offices);
                _ctx.SaveChanges();
            }

            //Seed Pantry
            List<Pantry> pantries = SeedPantry();

            if (!_ctx.Pantries.Any())
            {
                _ctx.Pantries.AddRange(pantries);
                _ctx.SaveChanges();
            }

            //Seed Supplies
            List<Supply> supplies = SeedSupplies();

            if (!_ctx.Supplies.Any())
            {
                _ctx.Supplies.AddRange(supplies);
                _ctx.SaveChanges();
            }
        }

        private List<Supply> SeedSupplies()
        {
            var supplies = new List<Supply>();
            var ingredients = new List<string> { "Beans", "Sugar", "Milk" };

            foreach (var p in _ctx.Pantries)
            {
                foreach (var i in ingredients)
                {
                    var supply = new Supply
                    {
                        Id = Guid.NewGuid(),
                        Description = i,
                        PantryId = p.Id,
                        Units = 45
                    };
                    supplies.Add(supply);
                }
            }

            return supplies;
        }

        private List<Pantry> SeedPantry()
        {
            return new List<Pantry>
            {
                new Pantry
                {
                    Id = Guid.NewGuid(),
                    Name = "Manila - Pantry A",
                    OfficeId = _ctx.Offices.SingleOrDefault(p=> p.Name == "Manila").Id
                },
                new Pantry
                {
                    Id = Guid.NewGuid(),
                    Name = "Manila - Pantry B",
                    OfficeId = _ctx.Offices.SingleOrDefault(p=> p.Name == "Manila").Id
                },
                new Pantry
                {
                    Id = Guid.NewGuid(),
                    Name = "Sydney - Pantry A",
                    OfficeId = _ctx.Offices.SingleOrDefault(p=> p.Name == "Sydney").Id
                }
            };
        }

        private static List<Office> SeedOffice()
        {
            return new List<Office>
            {
                new Office
                {
                    Id = Guid.NewGuid(),
                    Name = "Manila"
                },
                new Office
                {
                    Id = Guid.NewGuid(),
                    Name = "Sydney"
                }
            };
        }

        private static List<Coffee> SeedCoffee()
        {
            return new List<Coffee>
            {
                new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Double Americano",
                    UnitsOfBeans = 3,
                    UnitsOfMilk = 0,
                    UnitsOfSugar = 0
                },
                new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Sweet Latte",
                    UnitsOfBeans = 2,
                    UnitsOfMilk = 3,
                    UnitsOfSugar = 5
                },
                new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Flat White",
                    UnitsOfBeans = 2,
                    UnitsOfMilk = 4,
                    UnitsOfSugar = 1
                }
            };
        }
    }
}
