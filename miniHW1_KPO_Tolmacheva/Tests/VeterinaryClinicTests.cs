using NUnit.Framework;
using System;
using System.IO;
using miniHW1_KPO_Tolmacheva.Services;
using miniHW1_KPO_Tolmacheva.Names.Animals;

namespace ZooERP.Tests
{
  [TestFixture]
  public class VeterinaryClinicTests
  {
    private VeterinaryClinic clinic;

    [SetUp]
    public void Setup()
    {
      clinic = new VeterinaryClinic();
    }

    [Test]
    public void Inspect_ShouldReturnTrueWhenInputIsY()
    {
      var animal = new Rabbit("Bunny", 5, 1, 7);
      using (var sr = new StringReader("y"))
      {
        Console.SetIn(sr);
        bool result = clinic.Inspect(animal);
        Assert.IsTrue(result);
        Assert.IsTrue(animal.IsHealthy);
      }
    }

    [Test]
    public void Inspect_ShouldReturnFalseWhenInputIsN()
    {
      var animal = new Rabbit("Bunny", 5, 1, 7);
      using (var sr = new StringReader("n"))
      {
        Console.SetIn(sr);
        bool result = clinic.Inspect(animal);
        Assert.IsFalse(result);
        Assert.IsFalse(animal.IsHealthy);
      }
    }
  }
}
