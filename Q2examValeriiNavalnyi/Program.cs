/*
 * Program: Fleet Management System
 * Author : Valerii Navalnyi
 * Date   : 13.05.2025
 * Purpose: To track and manage different types of vehicles
 */

using System;
using System.ComponentModel;
using static System.Console;

namespace Q2examValeriiNavalnyi
{
    class Program
    {
        static void Main(string[] args)
        {

            // Vehicles objects and data instantiated in the list:

            List<Vehicle> vehicles = new List<Vehicle>()
            { 
                new Vehicle(50, 15.0, 30), // 3 arguments for Capacity (L), Efficiency (km/L), Fuel Level (L)
                new Vehicle(45, 12.0, 40),
                new Vehicle(45, 14.0, 25),
                new HybridVehicle(10, 10.0, 20, 75, 5.0, 50), // more arguments for battery-related data
                new HybridVehicle(35, 11.0, 15, 90, 4.5, 60),
                new HybridVehicle(30, 9.0, 10, 50, 6.0, 30),
            };
            
            // Displaying ToString method calls for all vehicles (MaxRange() method called inside):

            foreach (Vehicle vehicle in vehicles)
            {
                WriteLine($"{vehicle.ToString()}\n");
            }

            // Showing trip feasiblity for all vehicles:

            List<int> tripFeasbilityDistance = [70, 100, 1000, 250, 500, 130];
            List<string> tripFeasibilityMode = ["Eco", "Normal", "Sport", "Eco", "Normal", "Sport"];
            for (int i = 0; i < vehicles.Count; i++)
            {
                vehicles[i].TripFeasible(tripFeasbilityDistance[i], tripFeasibilityMode[i]);

            }

            // Displaying the HighestRange and AverageRange methods

            HighestRange(vehicles);
            AverageRange(vehicles);

        }  // End of Main method

        static void HighestRange(List<Vehicle> vehicles)
        {
            double highestRange = 0;
            int vehicleNum = 0;
            foreach(Vehicle vehicle in vehicles)
            {
                // Storing result in a variable to avoid looping numerous times

                double result = vehicle.MaxRange(); 
                if (result > highestRange)
                {
                    highestRange = result;
                    vehicleNum = vehicle.ID;
                }
            }

            WriteLine($"\nVehicle with highest range: {vehicleNum}");

        } // End of HighestRange method

        static void AverageRange(List<Vehicle> vehicles)
        {
            double averageRange = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                averageRange += vehicle.MaxRange();
            }
            WriteLine($"\nAverage range of all vehicles: {averageRange/vehicles.Count} km");

        } // End of AverageRange method 
    }

}
