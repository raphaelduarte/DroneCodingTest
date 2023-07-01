using DroneCodingTest;
using DroneCodingTest.Models;
using DroneCodingTest.Services;
using System;

var drone = new Drone();
var readInput = new ReadInputDataService();
var planDeliveries = new PlanDeliveries();
var result = planDeliveries.SolveAlgorithm();


int i = 0;
drone = readInput.GetDronesOrded(readInput.ReadInputData()).First();


foreach (var trip in result)
{ 
    Console.WriteLine(" ");
    Console.WriteLine($"{drone}");

    Console.WriteLine($"Trip: #{i + 1}");
    foreach (var package in trip)
    {

        Console.WriteLine(package);
    }
    i++;
    Console.WriteLine(" ");
    Console.WriteLine("----");
}
