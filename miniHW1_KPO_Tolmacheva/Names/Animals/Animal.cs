using miniHW1_KPO_Tolmacheva.Interfaces;

namespace miniHW1_KPO_Tolmacheva.Names.Animals
{
    public abstract class Animal : IAlive, IInventory
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public int Number { get; set; }
        public bool IsHealthy { get; set; }
    }
}

