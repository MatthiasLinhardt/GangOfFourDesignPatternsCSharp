using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyweightPattern
{
    public class Car
    {
        public Guid Id { get; private set; }
        public Vehicle VehicleData { get; private set; }
        public string LicencePlate { get; private set; }
        public string Color { get; private set; }
        public bool IsInParkingLot { get; private set; }
        public DateTime LastSafetyCheck { get; internal set; }

        public Car(Vehicle vehicleData, string licencePlate, string color)
        {
            Id = Guid.NewGuid();
            VehicleData = vehicleData;
            LicencePlate = licencePlate;
            Color = color;
            IsInParkingLot = true;
        }
        
        public bool RentForDriveToCustomer()
        {
            if (IsAvailableForDrivingToCustomer())
            {
                IsInParkingLot = false;

                return true;
            }

            return false;
        }

        public bool IsAvailableForDrivingToCustomer()
        {
            bool hasBeenCheckedRecently = LastSafetyCheck > DateTime.Today - TimeSpan.FromDays(90);

            return IsInParkingLot && hasBeenCheckedRecently;
        }

        public void BringBackToParkingLot()
        {
            IsInParkingLot = true;
        }
    }
}
