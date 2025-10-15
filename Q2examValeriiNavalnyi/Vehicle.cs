using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Q2examValeriiNavalnyi
{
    internal class Vehicle
    {
        private static int _nextVehicleID = 0; // static backing field, shared for all members
        
        // Backing fields, where data is actually stored:

        private int _ID;
        private int _capacity;      // Litres
        private double _efficiency; // km/L
        private int _fuelLevel;     // Litres

        // Properties to access and change data reliably and securely
        public int ID
        {
            get { return _ID; } // just getters - no need to change id
        }
        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        public double Efficiency
        {
            get { return _efficiency; }
            set { _efficiency = value; }
        }
        public int FuelLevel
        {
            get { return _fuelLevel; }
            set { _fuelLevel = value; }
        }

        public Vehicle()
        {
            _nextVehicleID++;
            _ID = _nextVehicleID;
        } // End of base parameterless constructor

        public Vehicle(int capacity, double efficiency, int fuelLevel)
        {
            _nextVehicleID++;
            _ID = _nextVehicleID;

            Capacity = capacity;
            Efficiency = efficiency;
            FuelLevel = fuelLevel;
        } // End of base parameterised constructor

        public virtual double MaxRange()
        {
            return Capacity * Efficiency;
        } // End of MaxRange base method

        public virtual void TripFeasible(double distance, string drivingMode)
        {
            
            double modeImpact = drivingMode switch
            {
                "Eco" => 0.1,    // increased efficiency by 10%
                "Normal" => 0,   // default
                "Sport" => -0.15 // reduced efficiency by 15%
            };

            // Trip feasibility calculated based on current Fuel Level, vehicle efficiency and driving mode

            double calculation = FuelLevel*(Efficiency+(Efficiency*modeImpact));

            // Ternary operator used for conciseness. Example:
            // variable = condition ? yes : no;

            bool condition = calculation > distance ? true : false;

            // appropriate output based on condition

            if (condition)
            {
                WriteLine($"Vehicle {ID} can complete the trip.");
            }
            else
            {
                WriteLine($"Vehicle {ID} does not have enough fuel for the trip.");
            }
        } // End of TripFeasible base method

        public override string ToString()
        {
            return $"VehicleID: {ID}, Fuel Tank: {Capacity}L, Fuel Efficiency: {Efficiency} km/L, Current Fuel: {FuelLevel}L, Range: {MaxRange()} km";
        } // End of ToString base method

    } // End of base class Vehicle

    internal class HybridVehicle : Vehicle
    {
        // Additional fields that extend Vehicle class

        private int _batteryCapacity;       // kWh
        private double _batteryEfficiency;  // km/kWh
        private int _batteryCharge;         // kWh

        // Additional Properties for newly created fields
        public int BatteryCapacity
        {
            get { return _batteryCapacity; }
            set { _batteryCapacity = value; }
        }
        public double BatteryEfficiency
        {
            get { return _batteryEfficiency; }
            set { _batteryEfficiency = value; }
        }
        public int BatteryCharge
        {
            get { return _batteryCharge; }
            set { _batteryCharge = value; }
        }

        public HybridVehicle(int capacity, double efficiency, int fuelLevel, int batteryCapacity, double batteryEfficiency, int batterCharge) : base(capacity, efficiency, fuelLevel)
        {
            BatteryCapacity = batteryCapacity;
            BatteryEfficiency = batteryEfficiency;
            BatteryCharge = batterCharge;
        }
        public override double MaxRange()
        {
            // Formula:
            // Total range = fuel tank capacity * fuel efficiency + (battery capacity * battery eff.)

            return Capacity * Efficiency + (BatteryCapacity * BatteryEfficiency);
        } // End of MaxRange method

        public override void TripFeasible(double distance, string drivingMode)
        {

            double modeImpact = drivingMode switch
            {
                "Eco" => 0.1,    // increased efficiency by 10%
                "Normal" => 0,   // default, no change
                "Sport" => -0.15 // reduced efficiency by 15%
            };

            // Formula for Hybrid Vehicle is different:
            // Fuel Level * (Efficiency + (Efficiency * modeImpace) + (Battery Charge * Battery Efficiency)

            double calculation = FuelLevel * (Efficiency + (Efficiency * modeImpact)) + (BatteryCharge * BatteryEfficiency);

            // ternary operator used for conciseness
            // variable = condition ? yes : no;

            bool condition = calculation > distance ? true : false;

            // Appropriate output based on condition

            if (condition)
            {
                WriteLine($"Vehicle {ID} can complete the trip.");
            }
            else
            {
                WriteLine($"Vehicle {ID} does not have enough fuel for the trip.");
            }

        } // End of TripFeasible method

        public override string ToString()
        {

            string baseInfo = base.ToString();
            return $"{baseInfo}, Battery: {BatteryCapacity} kWh, Battery Efficiency: {BatteryEfficiency} km/kWh, Current Battery: {BatteryCharge} kWh";

        } // End of overridden ToString method to display base and additional properties of Hybrid Vehicle

    } // End of derived class HybridVehicle
}
