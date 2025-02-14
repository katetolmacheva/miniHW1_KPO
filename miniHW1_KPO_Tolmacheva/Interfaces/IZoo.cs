using System.Collections.Generic;
using miniHW1_KPO_Tolmacheva.Names.Animals;
using miniHW1_KPO_Tolmacheva.Names.Employees;
using miniHW1_KPO_Tolmacheva.Interfaces;

namespace miniHW1_KPO_Tolmacheva.Interfaces
{
    public interface IZoo
  {
    void AddAnimal(Animal animal);
    void AddThing(IInventory thing);
    void AddEmployee(Employee employee);

    int GetTotalFoodConsumptionForAnimals();
    int GetTotalFoodConsumptionForEmployees();
    int GetTotalFoodConsumptionForAll();

    IEnumerable<Animal> GetAllAnimals();
    IEnumerable<Employee> GetEmployees();
    IEnumerable<Animal> GetContactZooAnimals();
    IEnumerable<IInventory> GetThingsInventory();
    IEnumerable<IInventory> GetAllInventoryItems();

    bool IsInventoryNumberUnique(int number);
    bool IsEmployeeIdUnique(int id);
  }
}

