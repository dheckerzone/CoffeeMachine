using AutoMapper;
using CoffeeMachine.ViewModel;
using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine
{
  public class DomainProfile : Profile
  {
    public DomainProfile()
    {
      CreateMap<CoffeeResource, Coffee>().ReverseMap();

      CreateMap<Pantry, OfficePantryResource>()
          .ForMember(dest => dest.PantryId, opts => opts.MapFrom(src => src.Id))
          .ForMember(dest => dest.Pantry, opts => opts.MapFrom(src => src.Name))
          .ForMember(dest => dest.OfficeId, opts => opts.MapFrom(src => src.Office.Id))
          .ForMember(dest => dest.Office, opts => opts.MapFrom(src => src.Office.Name)).ReverseMap();

      CreateMap<Supply, SuppliesResource>()
          .ForMember(dest => dest.OfficePantry, opts => opts.Ignore())
          .ForMember(dest => dest.OfficePantry, opts => opts.MapFrom(src => Mapper.Map<Pantry, OfficePantryResource>(src.Pantry)));

      CreateMap<Order, OrderHistoryResource>()
          .ForMember(dest=> dest.Office, opts => opts.MapFrom(src => src.Pantry.Office.Name))
          .ForMember(dest => dest.Pantry, opts => opts.MapFrom(src => src.Pantry.Name))
          .ForMember(dest => dest.Coffee, opts => opts.MapFrom(src => src.Coffee.Name))
          .ReverseMap();

    }
  }
}
