using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyweightPattern
{
    public abstract class Vehicle
    {
        public string ManufacturerName { get; internal set; }
        public string ModelName { get; internal set; }
        public int NumberOfSeats { get; internal set; }
        public int VolumeOfTrunkInLiters { get; internal set; }
        public double AverageFuelConsumption { get; internal set; }
        public FuelType FuelType { get; internal set; }
        public bool IsAutomaticGear { get; internal set; }
        public bool HasNavigationSystem { get; internal set; }
    }

    public class VehicleForAllEmployees : Vehicle
    {
    }

    //There could be more concrete vehicles, e.g. vehicles for private usage.
}
