using System;

namespace CoffeeMachine.ViewModel
{
  public class OrderHistoryResource
  {
    public string Coffee { get; set; }

    public string Pantry { get; set; }

    public string Office { get; set; }

    public DateTime OrderDate { get; set; }
  }
}
