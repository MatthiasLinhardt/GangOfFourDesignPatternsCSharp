using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyweightPattern
{
    public class VehicleFactory
    {
        private Dictionary<VehicleType, Vehicle> vehicles = new Dictionary<VehicleType, Vehicle>();

        public Vehicle GetVehicle(VehicleType vehicleType)
        {
            Vehicle vehicle;

            if (vehicles.ContainsKey(vehicleType))
            {
                vehicle = vehicles[vehicleType];
            }
            else
            {
                switch (vehicleType)
                {
                    case VehicleType.VwKombi:
                        vehicle = new VehicleForAllEmployees()
                        {
                            ManufacturerName = "VW   ",
                            ModelName = "Passat",
                            AverageFuelConsumption = 6.5,
                            FuelType = FuelType.Benzin,
                            HasNavigationSystem = false,
                            IsAutomaticGear = false,
                            NumberOfSeats = 4,
                            VolumeOfTrunkInLiters = 180
                        };
                        break;
                    case VehicleType.SkodaKombi:
                        vehicle = new VehicleForAllEmployees()
                        {
                            ManufacturerName = "Skoda",
                            ModelName = "Superb",
                            AverageFuelConsumption = 5.0,
                            FuelType = FuelType.Diesel,
                            HasNavigationSystem = true,
                            IsAutomaticGear = false,
                            NumberOfSeats = 5,
                            VolumeOfTrunkInLiters = 220
                        };
                        break;
                    case VehicleType.AudiKombi:
                        vehicle = new VehicleForAllEmployees()
                        {
                            ManufacturerName = "Audi ",
                            ModelName = "A4    ",
                            AverageFuelConsumption = 6.0,
                            FuelType = FuelType.Diesel,
                            HasNavigationSystem = true,
                            IsAutomaticGear = true,
                            NumberOfSeats = 5,
                            VolumeOfTrunkInLiters = 250
                        };
                        break;
                    default:
                        throw new ArgumentException("Unknown VehicleType");
                }

                vehicles.Add(vehicleType, vehicle);
            }

            return vehicle;
        }
    }

}
