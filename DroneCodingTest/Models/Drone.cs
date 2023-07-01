using System;
namespace DroneCodingTest.Models
{
    public class Drone
    {
        public Drone() { }
        public Drone(string name, int maxWeight, List<Package> deliveries)
        {
            Name = name;
            MaxWeight = maxWeight;
            Deliveries = deliveries;

        }

        public Drone(string name, int maxWeight)
        {
            Name = name;
            MaxWeight = maxWeight;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetMaxWeight()
        {
            return MaxWeight;
        }

        public override string ToString()
        {
            return $"Drone: {Name}";
        }

        private string Name { get; set; }
        private int MaxWeight { get; set; }
        public List<Package> Deliveries { get; set; }
    }
}
