using NUnit.Framework;
using System.Linq;
using miniHW1_KPO_Tolmacheva.Services;
using miniHW1_KPO_Tolmacheva.Names.Animals;
using miniHW1_KPO_Tolmacheva.Names.Employees;
using miniHW1_KPO_Tolmacheva.Names.Things;
using miniHW1_KPO_Tolmacheva.Interfaces;

namespace miniHW1_KPO_Tolmacheva.Tests
{
  [TestFixture]
  public class ZooTests
  {
    private IZoo zoo;

    [SetUp]
    public void Setup()
    {
      zoo = new Zoo();
    }

    [Test]
    public void AddAnimal_ShouldAddAnimalAndInventoryItem()
    {
      var animal = new Rabbit("Bunny", 5, 1, 7);
      zoo.AddAnimal(animal);
      var animals = zoo.GetAllAnimals();
      var inventory = zoo.GetAllInventoryItems();
      Assert.AreEqual(1, animals.Count());
      Assert.AreEqual(animal, animals.First());
      Assert.IsTrue(inventory.Contains(animal));
    }

    [Test]
    public void GetTotalFoodConsumptionForAnimals_ShouldReturnCorrectSum()
    {
      var animal1 = new Rabbit("Bunny", 5, 1, 7);
      var animal2 = new Tiger("Stripes", 10, 2);
      zoo.AddAnimal(animal1);
      zoo.AddAnimal(animal2);
      Assert.AreEqual(15, zoo.GetTotalFoodConsumptionForAnimals());
    }

    [Test]
    public void AddThing_ShouldAddThingToInventory()
    {
      var table = new Table("Office Table", 3);
      zoo.AddThing(table);
      var inventory = zoo.GetAllInventoryItems();
      Assert.IsTrue(inventory.Contains(table));
    }

    [Test]
    public void AddEmployee_ShouldAddEmployee()
    {
      var employee = new Employee("Alice", 3, 100);
      zoo.AddEmployee(employee);
      var employees = zoo.GetEmployees();
      Assert.AreEqual(1, employees.Count());
      Assert.AreEqual("Alice", employees.First().Name);
    }

    [Test]
    public void IsInventoryNumberUnique_ShouldReturnFalseForDuplicateNumber()
    {
      var table = new Table("Office Table", 3);
      zoo.AddThing(table);
      Assert.IsFalse(zoo.IsInventoryNumberUnique(3));
    }

    [Test]
    public void IsEmployeeIdUnique_ShouldReturnFalseForDuplicateId()
    {
      var employee = new Employee("Alice", 3, 100);
      zoo.AddEmployee(employee);
      Assert.IsFalse(zoo.IsEmployeeIdUnique(100));
    }

    [Test]
    public void GetThingsInventory_ShouldReturnOnlyThings()
    {
      var table = new Table("Office Table", 3);
      var rabbit = new Rabbit("Bunny", 5, 1, 7);
      zoo.AddThing(table);
      zoo.AddAnimal(rabbit);
      var things = zoo.GetThingsInventory();
      Assert.IsTrue(things.Contains(table));
      Assert.IsFalse(things.Contains(rabbit));
    }

    [Test]
    public void GetContactZooAnimals_ShouldReturnOnlyHerbivoresWithHighKindness()
    {
      var rabbit = new Rabbit("Bunny", 5, 1, 7);
      var monkey = new Monkey("George", 4, 2, 5);
      var tiger = new Tiger("Stripes", 10, 3);
      zoo.AddAnimal(rabbit);
      zoo.AddAnimal(monkey);
      zoo.AddAnimal(tiger);
      var contactAnimals = zoo.GetContactZooAnimals();
      Assert.AreEqual(1, contactAnimals.Count());
      Assert.AreEqual("Bunny", contactAnimals.First().Name);
    }

    [Test]
    public void GetTotalFoodConsumptionForAll_ShouldReturnSumOfAnimalsAndEmployees()
    {
      var rabbit = new Rabbit("Bunny", 5, 1, 7);
      zoo.AddAnimal(rabbit);
      var employee = new Employee("Alice", 3, 100);
      zoo.AddEmployee(employee);
      Assert.AreEqual(8, zoo.GetTotalFoodConsumptionForAll());
    }


    [Test]
    public void GetTotalFoodConsumptionForAnimals_ShouldReturnZero_WhenNoAnimalsAdded()
    {
      Assert.AreEqual(0, zoo.GetTotalFoodConsumptionForAnimals());
    }

    [Test]
    public void GetTotalFoodConsumptionForEmployees_ShouldReturnZero_WhenNoEmployeesAdded()
    {
      Assert.AreEqual(0, zoo.GetTotalFoodConsumptionForEmployees());
    }

    [Test]
    public void GetAllInventoryItems_ShouldReturnBothAnimalsAndThings()
    {
      var rabbit = new Rabbit("Bunny", 5, 1, 7);
      var table = new Table("Office Table", 3);
      zoo.AddAnimal(rabbit);
      zoo.AddThing(table);
      var allInventory = zoo.GetAllInventoryItems();
      Assert.AreEqual(2, allInventory.Count());
      Assert.IsTrue(allInventory.Contains(rabbit));
      Assert.IsTrue(allInventory.Contains(table));
    }

    [Test]
    public void GetAllAnimals_ShouldReturnOnlyAnimals()
    {
      var rabbit = new Rabbit("Bunny", 5, 1, 7);
      var tiger = new Tiger("Stripes", 10, 2);
      var table = new Table("Office Table", 3);
      zoo.AddAnimal(rabbit);
      zoo.AddAnimal(tiger);
      zoo.AddThing(table);
      var animals = zoo.GetAllAnimals();
      Assert.AreEqual(2, animals.Count());
      Assert.IsTrue(animals.Contains(rabbit));
      Assert.IsTrue(animals.Contains(tiger));
      Assert.IsFalse(animals.Any(a => a.GetType() == typeof(Table)));
    }

    [Test]
    public void GetEmployees_ShouldReturnOnlyEmployees()
    {
      var employee1 = new Employee("Alice", 3, 100);
      var employee2 = new Employee("Bob", 4, 101);
      var table = new Table("Office Table", 3);
      zoo.AddEmployee(employee1);
      zoo.AddEmployee(employee2);
      zoo.AddThing(table);
      var employees = zoo.GetEmployees();
      Assert.AreEqual(2, employees.Count());
      Assert.IsTrue(employees.Contains(employee1));
      Assert.IsTrue(employees.Contains(employee2));
    }

    [Test]
    public void IsInventoryNumberUnique_ShouldReturnTrue_WhenNumberNotUsed()
    {
      Assert.IsTrue(zoo.IsInventoryNumberUnique(99));
    }

    [Test]
    public void IsEmployeeIdUnique_ShouldReturnTrue_WhenIdNotUsed()
    {
      Assert.IsTrue(zoo.IsEmployeeIdUnique(999));
    }
  }
}

