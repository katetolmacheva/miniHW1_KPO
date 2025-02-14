using System.Collections.Generic;
using System.Linq;
using miniHW1_KPO_Tolmacheva.Names.Animals;
using miniHW1_KPO_Tolmacheva.Names.Employees;
using miniHW1_KPO_Tolmacheva.Interfaces;

namespace miniHW1_KPO_Tolmacheva.Services
{
    public class Zoo : IZoo
  {
    private readonly List<Animal> animals;
    private readonly List<Employee> employees;
    private readonly List<IInventory> inventoryItems;

    public Zoo()
    {
      animals = new List<Animal>();
      employees = new List<Employee>();
      inventoryItems = new List<IInventory>();
    }

    public void AddAnimal(Animal animal)
    {
      animals.Add(animal);
      inventoryItems.Add(animal);
    }

    public void AddThing(IInventory thing)
    {
      inventoryItems.Add(thing);
    }

    public void AddEmployee(Employee employee)
    {
      employees.Add(employee);
    }

    public int GetTotalFoodConsumptionForAnimals() => animals.Sum(a => a.Food);
    public int GetTotalFoodConsumptionForEmployees() => employees.Sum(e => e.Food);
    public int GetTotalFoodConsumptionForAll() => GetTotalFoodConsumptionForAnimals() + GetTotalFoodConsumptionForEmployees();

    public IEnumerable<Animal> GetAllAnimals() => animals;
    public IEnumerable<Employee> GetEmployees() => employees;
    public IEnumerable<Animal> GetContactZooAnimals() =>
        animals.OfType<Herbivore>().Where(h => h.KindnessLevel > 5);
    public IEnumerable<IInventory> GetThingsInventory() =>
        inventoryItems.Where(i => !(i is Animal));
    public IEnumerable<IInventory> GetAllInventoryItems() => inventoryItems;

    public bool IsInventoryNumberUnique(int number) =>
        !inventoryItems.Any(item => item.Number == number);

    public bool IsEmployeeIdUnique(int id) =>
        !employees.Any(emp => emp.EmployeeId == id);
  }
}

