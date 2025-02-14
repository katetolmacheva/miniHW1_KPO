using Microsoft.Extensions.DependencyInjection;
using miniHW1_KPO_Tolmacheva.Apps;
using miniHW1_KPO_Tolmacheva.Interfaces;
using miniHW1_KPO_Tolmacheva.Services;

namespace miniHW1_KPO_Tolmacheva
{
  class Program
  {
    static void Main(string[] args)
    {
      var services = new ServiceCollection();
      services.AddSingleton<IZoo, Zoo>();
      services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
      services.AddSingleton<ZooApp>();

      var serviceProvider = services.BuildServiceProvider();
      var app = serviceProvider.GetService<ZooApp>();
      app.Run();
    }
  }
}