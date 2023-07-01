using System.Globalization;
using DroneCodingTest.Models;
using DroneCodingTest.Services;
using System;

namespace DroneCodingTest
{
    public class PlanDeliveries
    {
        public PlanDeliveries()
        {
        }

        private Drone _drone { get; set; }
        private Package _package { get; set; }

        private ReadInputDataService _readInputDataService { get; set; } = new ReadInputDataService();

        public PlanDeliveries(Drone drone, Package package, ReadInputDataService readInputDataService)
        {
            _drone = drone;
            _package = package;
            _readInputDataService = readInputDataService;
        }

        public List<List<Package>> SolveAlgorithm()
        {
            var inputData = _readInputDataService.ReadInputData();

            var drone = _readInputDataService.GetDronesOrded(inputData)[0];
            var packages = _readInputDataService.GetPackagesOrded();
            var deliveries = new List<Package>();
            var tripItem = new List<List<Package>>();
            

            int sumWeightPackages = 0;
            drone.Deliveries = new List<Package>();




            for (int i = 0; i < packages.Count; i++)
            {
                i = 0;
                if (packages[i].GetPackageWeight() <= drone.GetMaxWeight())
                {
                    sumWeightPackages = packages[i].GetPackageWeight();
                    drone.Deliveries.Add(packages[i]);
                    packages.RemoveAt(i);

                    for (int j = 0; j < packages.Count; j++)
                    {
                        if (sumWeightPackages + packages[j].GetPackageWeight() <= drone.GetMaxWeight())
                        {
                            sumWeightPackages += packages[j].GetPackageWeight();
                            drone.Deliveries.Add(packages[j]);
                            packages.RemoveAt(j);
                        }
                    }
                }

                tripItem.Add(new List<Package>(drone.Deliveries));

                drone.Deliveries = new List<Package>();
            }
            return tripItem;
        }
    }
}
