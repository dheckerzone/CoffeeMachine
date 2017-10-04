using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using CoffeeMachine.ViewModel;
using CoffeeMachine.Services;
using EF;

namespace CoffeeMachine
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddScoped<ICoffeeService, CoffeeService>();
      services.AddScoped<IOfficePantryService, OfficePantryService>();
      services.AddScoped<ISupplyService, SupplyService>();
      services.AddScoped<IOrderService, OrderService>();

      services.AddScoped<CoffeeMachineDbContext>();

      services.AddTransient<DbInitializer>();
      // Add framework services.
      services.AddMvc();

      services.AddAutoMapper();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DbInitializer initializer)
    {
      //ConfigureMapping();

      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "api/{controller=Home}/{action=Index}/{id?}");
      });

      initializer.Seed();
    }

    private void ConfigureMapping()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<Coffee, CoffeeResource>().ReverseMap();
        cfg
            .CreateMap<CoffeeResource, Coffee>()
            .ForMember(m => m.Id, opt => opt.Ignore())
            .ReverseMap();
      });



      Mapper.AssertConfigurationIsValid();
    }
  }
}
