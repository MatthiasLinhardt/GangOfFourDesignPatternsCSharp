using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyweightPattern
{
    class Program
    {
        private static readonly VehicleFactory VehicleFactory = new VehicleFactory();
        private static readonly List<Car> CarsOwnedByCompany = new List<Car>();
        private const string ColorBlack = "schwarz";
        private const string ColorGreen = "silbern";

        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                var car = new Car(GetRandomVehicle(i), GetRandomLicencePlate(i), GetRandomColor(i));
                CarsOwnedByCompany.Add(car);
            }
            Console.WriteLine("\nAlle Autos werden Check-Heft geprüft und gewartet.");
            CheckAllCarsForRepairs();
            Console.WriteLine("\nIch brauche ein Auto, um zum Kunden zu fahren. Welche sind verfügbar?");
            ShowMeAllAvailableCars();
            Console.WriteLine("\n(In der Zwischenzeit: Einige Mitarbeiter leihen Autos aus)");
            RentSomeCarsForDrivingToCustomer();
            Console.WriteLine("\nIch brauche ein schwarzes Auto, um zum Kunden zu fahren. Welche sind verfügbar?");
            ShowMeAllAvailableCars(ColorBlack);
            Console.WriteLine("\nWelches davon wurde vor max. 60 Tagen gewartet, hat Navi, aber keine Automatik?");
            ShowMeAllAvailableCars(ColorBlack, true, false, 60);

            Console.ReadLine();
        }

        private static Vehicle GetRandomVehicle(int i)
        {
            var numberOfDifferentVehiclesOwnedByThisCompany = Enum.GetValues(typeof (VehicleType)).Length;
                
            return VehicleFactory.GetVehicle((VehicleType) (i % numberOfDifferentVehiclesOwnedByThisCompany));
        }

        private static string GetRandomLicencePlate(int i)
        {
            return "BA-XX-" + i + ((i < 10) ? " " : "");
        }

        private static string GetRandomColor(int i)
        {
            return (i % 2 == 0) ? ColorGreen : ColorBlack;
        }

        private static void CheckAllCarsForRepairs()
        {
            for (int i = 0; i < CarsOwnedByCompany.Count; i++)
            {
                CarsOwnedByCompany[i].LastSafetyCheck = DateTime.Today.AddDays(-(50 + i));
            }
        }

        private static void RentSomeCarsForDrivingToCustomer()
        {
            for (int i = 0; i < CarsOwnedByCompany.Count; i++)
            {
                if (i % 4 == 0 && CarsOwnedByCompany[i].IsAvailableForDrivingToCustomer())
                {
                    CarsOwnedByCompany[i].RentForDriveToCustomer();
                }
            }
        }

        private static void ShowMeAllAvailableCars(string color = null, bool? hasNavi = null, bool? isAutomatic = null, int daysSinceLastCheck = 365)
        {
            foreach (Car car in CarsOwnedByCompany)
            {
                if (car.IsAvailableForDrivingToCustomer()
                    && (color == null || car.Color == color) 
                    && (hasNavi == null || car.VehicleData.HasNavigationSystem == hasNavi)
                    && (isAutomatic == null || car.VehicleData.IsAutomaticGear == isAutomatic)
                    && car.LastSafetyCheck > DateTime.Today - TimeSpan.FromDays(daysSinceLastCheck))
                {
                    Console.WriteLine(car.LicencePlate +
                        " " + car.VehicleData.ManufacturerName + " " + car.VehicleData.ModelName +
                        " " + car.Color +
                        " " + ((car.VehicleData.HasNavigationSystem) ? " mit Navi" : "ohne Navi") +
                        " " + ((car.VehicleData.IsAutomaticGear) ? " mit Automatik" : "ohne Automatik") +
                        " Gewartet: " + car.LastSafetyCheck.ToShortDateString());
                }
            }
        }
    }
}
