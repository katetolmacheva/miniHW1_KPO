using miniHW1_KPO_Tolmacheva.Interfaces;

namespace miniHW1_KPO_Tolmacheva.Names.Things
{
    public class Thing : IInventory
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Thing(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}

