using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Model
{
    public partial class Vehicle
    {
        public Vehicle(string vinNumber, string licensePlate, string brandModel, VehicleType categorie, string? color, int? doors, FuelType fuel)
        {
            VinNumber = vinNumber;
            LicensePlate = licensePlate;
            BrandModel = brandModel;
            Categorie = categorie;
            Color = color;
            Doors = doors;
            Fuel = fuel;
        }

        public string VinNumber { get; private set; }
        public string LicensePlate { get; set; }
        public string BrandModel { get; set; }
        public VehicleType Categorie { get; set; }
        public string? Color { get; set; }
        public int? Doors { get; set; }
        public FuelType Fuel { get; set; }
    }
}
