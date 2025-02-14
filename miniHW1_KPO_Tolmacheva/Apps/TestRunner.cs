using System;
using NUnitLite;

namespace miniHW1_KPO_Tolmacheva.Apps
{
  public static class TestRunner
  {
    public static void RunTests()
    {
      Console.WriteLine("Запуск юнит тестов...");
      var args = new string[] { "--labels=All" };
      new AutoRun().Execute(args);
      Console.WriteLine("Юнит тесты завершены.");
    }
  }
}
