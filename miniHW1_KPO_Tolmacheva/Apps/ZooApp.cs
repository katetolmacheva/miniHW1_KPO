using System;
using miniHW1_KPO_Tolmacheva.Interfaces;
using miniHW1_KPO_Tolmacheva.Names.Animals;
using miniHW1_KPO_Tolmacheva.Names.Things;
using miniHW1_KPO_Tolmacheva.Apps;
using miniHW1_KPO_Tolmacheva.Names.Employees;

namespace miniHW1_KPO_Tolmacheva.Apps
{
    public class ZooApp
  {
    private readonly IZoo zoo;
    private readonly IVeterinaryClinic vetClinic;

    public ZooApp(IZoo zoo, IVeterinaryClinic vetClinic)
    {
      this.zoo = zoo;
      this.vetClinic = vetClinic;
    }

    public void Run()
    {
      bool exit = false;
      while (!exit)
      {
        Console.WriteLine("\nВыберите опцию:");
        Console.WriteLine("1. Добавить новое животное");
        Console.WriteLine("2. Добавить новую вещь");
        Console.WriteLine("3. Добавить нового сотрудника");
        Console.WriteLine("4. Отчет по потребляемой еде животных");
        Console.WriteLine("5. Отчет по потребляемой еде сотрудников");
        Console.WriteLine("6. Отчет по потребляемой еде всех живых существ");
        Console.WriteLine("7. Список животных для контактного зоопарка");
        Console.WriteLine("8. Список всех животных");
        Console.WriteLine("9. Список сотрудников");
        Console.WriteLine("10. Список инвентаря (только вещей)");
        Console.WriteLine("11. Список всего инвентаря (животные и вещи)");
        Console.WriteLine("12. Запустить юнит тесты");
        Console.WriteLine("13. Выход");
        Console.Write("Ваш выбор: ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        switch (choice)
        {
          case "1":
            AddAnimalFlow();
            break;
          case "2":
            AddThingFlow();
            break;
          case "3":
            AddEmployeeFlow();
            break;
          case "4":
            ShowAnimalsFoodReport();
            break;
          case "5":
            ShowEmployeesFoodReport();
            break;
          case "6":
            ShowAllFoodReport();
            break;
          case "7":
            ShowContactZooAnimals();
            break;
          case "8":
            ShowAllAnimals();
            break;
          case "9":
            ShowEmployees();
            break;
          case "10":
            ShowThingsInventory();
            break;
          case "11":
            ShowAllInventoryItems();
            break;
          case "12":
            TestRunner.RunTests();
            break;
          case "13":
            exit = true;
            break;
          default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            break;
        }
      }
    }

    private int ReadNonNegativeInt(string prompt)
    {
      int value;
      while (true)
      {
        Console.Write(prompt);
        string input = Console.ReadLine();
        if (!int.TryParse(input, out value) || value < 0)
        {
          Console.WriteLine("Некорректный ввод. Введите неотрицательное число.");
          continue;
        }
        break;
      }
      return value;
    }

    private int ReadUniqueInventoryNumber()
    {
      int number;
      while (true)
      {
        number = ReadNonNegativeInt("Введите инвентаризационный номер: ");
        if (!zoo.IsInventoryNumberUnique(number))
        {
          Console.WriteLine("Ошибка: Инвентаризационный номер уже используется. Попробуйте другой номер.");
          continue;
        }
        break;
      }
      return number;
    }

    private int ReadUniqueEmployeeId()
    {
      int id;
      while (true)
      {
        id = ReadNonNegativeInt("Введите идентификатор сотрудника: ");
        if (!zoo.IsEmployeeIdUnique(id))
        {
          Console.WriteLine("Ошибка: Идентификатор сотрудника уже используется. Попробуйте другой.");
          continue;
        }
        break;
      }
      return id;
    }

    private void AddAnimalFlow()
    {
      Console.WriteLine("Выберите тип животного:");
      Console.WriteLine("1. Кролик");
      Console.WriteLine("2. Обезьяна");
      Console.WriteLine("3. Тигр");
      Console.WriteLine("4. Волк");
      Console.Write("Ваш выбор: ");
      string typeChoice = Console.ReadLine();

      Console.Write("Введите имя животного: ");
      string name = Console.ReadLine();

      int food = ReadNonNegativeInt("Введите количество потребляемой еды (кг/день): ");
      int number = ReadUniqueInventoryNumber();

      Animal animal = null;
      switch (typeChoice)
      {
        case "1":
          int kindnessRabbit = ReadNonNegativeInt("Введите уровень доброты (0-10): ");
          while (kindnessRabbit > 10)
          {
            Console.WriteLine("Уровень доброты не может превышать 10. Попробуйте снова.");
            kindnessRabbit = ReadNonNegativeInt("Введите уровень доброты (0-10): ");
          }
          animal = new Rabbit(name, food, number, kindnessRabbit);
          break;
        case "2":
          int kindnessMonkey = ReadNonNegativeInt("Введите уровень доброты (0-10): ");
          while (kindnessMonkey > 10)
          {
            Console.WriteLine("Уровень доброты не может превышать 10. Попробуйте снова.");
            kindnessMonkey = ReadNonNegativeInt("Введите уровень доброты (0-10): ");
          }
          animal = new Monkey(name, food, number, kindnessMonkey);
          break;
        case "3":
          animal = new Tiger(name, food, number);
          break;
        case "4":
          animal = new Wolf(name, food, number);
          break;
        default:
          Console.WriteLine("Неверный выбор типа животного.");
          return;
      }

      if (vetClinic.Inspect(animal))
      {
        zoo.AddAnimal(animal);
        Console.WriteLine("Животное успешно добавлено в зоопарк.");
      }
      else
      {
        Console.WriteLine("Животное не прошло медосмотр и не добавлено.");
      }
    }

    private void AddThingFlow()
    {
      Console.WriteLine("Выберите тип вещи:");
      Console.WriteLine("1. Стол");
      Console.WriteLine("2. Компьютер");
      Console.WriteLine("3. Прочая вещь");
      Console.Write("Ваш выбор: ");
      string thingChoice = Console.ReadLine();

      Console.Write("Введите наименование вещи: ");
      string name = Console.ReadLine();
      int number = ReadUniqueInventoryNumber();

      IInventory thing = thingChoice switch
      {
        "1" => new Table(name, number),
        "2" => new Computer(name, number),
        "3" => new Names.Things.Thing(name, number),
        _ => null
      };

      if (thing == null)
      {
        Console.WriteLine("Неверный выбор типа вещи.");
        return;
      }

      zoo.AddThing(thing);
      Console.WriteLine("Вещь успешно добавлена в инвентарь зоопарка.");
    }

    private void AddEmployeeFlow()
    {
      Console.Write("Введите имя сотрудника: ");
      string name = Console.ReadLine();
      int food = ReadNonNegativeInt("Введите количество потребляемой еды (кг/день): ");
      int id = ReadUniqueEmployeeId();

      Employee employee = new Employee(name, food, id);
      zoo.AddEmployee(employee);
      Console.WriteLine("Сотрудник успешно добавлен.");
    }

    private void ShowAnimalsFoodReport()
    {
      int totalFood = zoo.GetTotalFoodConsumptionForAnimals();
      Console.WriteLine($"Общее количество еды, необходимое животным: {totalFood} кг/день");
    }

    private void ShowEmployeesFoodReport()
    {
      int totalFood = zoo.GetTotalFoodConsumptionForEmployees();
      Console.WriteLine($"Общее количество еды, необходимое сотрудникам: {totalFood} кг/день");
    }

    private void ShowAllFoodReport()
    {
      int totalFood = zoo.GetTotalFoodConsumptionForAll();
      Console.WriteLine($"Общее количество еды, необходимое всем живым существам: {totalFood} кг/день");
    }

    private void ShowContactZooAnimals()
    {
      var contactAnimals = zoo.GetContactZooAnimals();
      Console.WriteLine("Животные, пригодные для контактного зоопарка:");
      foreach (var animal in contactAnimals)
      {
        Console.WriteLine($"Имя: {animal.Name}, Инвентаризационный номер: {animal.Number}");
      }
    }

    private void ShowAllAnimals()
    {
      var animals = zoo.GetAllAnimals();
      Console.WriteLine("Список всех животных:");
      foreach (var animal in animals)
      {
        Console.WriteLine($"Имя: {animal.Name}, Инвентаризационный номер: {animal.Number}");
      }
    }

    private void ShowEmployees()
    {
      var employees = zoo.GetEmployees();
      Console.WriteLine("Список сотрудников:");
      foreach (var emp in employees)
      {
        Console.WriteLine($"Имя: {emp.Name}, Идентификатор: {emp.EmployeeId}");
      }
    }

    private void ShowThingsInventory()
    {
      var things = zoo.GetThingsInventory();
      Console.WriteLine("Список инвентаря (только вещи):");
      foreach (var item in things)
      {
        Console.WriteLine($"Наименование: {item.Name}, Инвентаризационный номер: {item.Number}, Вид: {item.GetType().Name}");
      }
    }

    private void ShowAllInventoryItems()
    {
      var items = zoo.GetAllInventoryItems();
      Console.WriteLine("Список всего инвентаря (животные и вещи):");
      foreach (var item in items)
      {
        Console.WriteLine($"Наименование: {item.Name}, Инвентаризационный номер: {item.Number}, Вид: {item.GetType().Name}");
      }
    }
  }
}

