using System;
namespace DroneCodingTest.Models
{
    public class Package
    {
        public Package(){}
        public Package(string name, int packageWeight)
        {
            Name = name;
            PackageWeight = packageWeight;

        }

        public Package(string name, string packageWeightString)
        {
            Name = name;
            PackageWeightString = packageWeightString;
        }

        public int GetPackageWeight()
        {
            return PackageWeight;
        }


        public override string ToString()
        {
            return $"Package: {Name}, Weight: {PackageWeight}";
        }

        private string Name { get; set; }
        private int PackageWeight { get; set; }

        private string PackageWeightString { get; set; }
    }
}
