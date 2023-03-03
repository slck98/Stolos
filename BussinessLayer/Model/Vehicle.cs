using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Model
{
    public partial class Vehicle
    {
        public Vehicle(string vinNumber, string numberPlate, string brandModel, VehicleType categorie, string? color, int? doors, FuelType feul)
        {
            VinNumber = vinNumber;
            NumberPlate = numberPlate;
            BrandModel = brandModel;
            Categorie = categorie;
            Color = color;
            Doors = doors;
            Fuel = feul;
        }

        public string VinNumber { get; private set; }
        public string NumberPlate { get; set; }
        public string BrandModel { get; set; }
        public VehicleType Categorie { get; set; }
        public string? Color { get; set; }
        public int? Doors { get; set; }
        public FuelType Fuel { get; set; }
    }
}
