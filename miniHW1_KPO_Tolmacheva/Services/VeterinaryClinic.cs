using System;
using miniHW1_KPO_Tolmacheva.Names.Animals;
using miniHW1_KPO_Tolmacheva.Interfaces;

namespace miniHW1_KPO_Tolmacheva.Services
{
    public class VeterinaryClinic : IVeterinaryClinic
  {
    public bool Inspect(Animal animal)
    {
      Console.WriteLine($"Проводится медосмотр для животного \"{animal.Name}\".");
      Console.Write("Является ли животное здоровым? (y/n): ");
      var input = Console.ReadLine();
      bool isHealthy = input?.Trim().ToLower() == "y";
      animal.IsHealthy = isHealthy;
      return isHealthy;
    }
  }
}

