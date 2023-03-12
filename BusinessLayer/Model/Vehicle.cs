using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Exceptions;

namespace BusinessLayer.Model
{
    public partial class Vehicle
    {
        private string _vinNumber;
        private string _licensePlate;
        private string _brandModel;
        private string _color;
        private int _doors;

        public Vehicle()
        {
        }

        public Vehicle(string vinNumber, string licensePlate, VehicleType categorie, FuelType fuel)
        {
            VinNumber = vinNumber;
            LicensePlate = licensePlate;
            Categorie = categorie;
            Fuel = fuel;
        }

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

        public string VinNumber 
        { 
            get { return _vinNumber; } 
            set 
            {
                if (value == null) throw new DomainException("Vehicle: set-VinNumber: NULL value");
                _vinNumber = value; 
            } 
        }
        public string LicensePlate 
        { 
            get { return _licensePlate; } 
            set 
            { 
                if (value == null) throw new DomainException("Vehicle: set-LicensePlate: NULL value"); 
                _licensePlate = value; 
            } 
        }
        public string BrandModel 
        {
            get { return _brandModel; }
            set { if (value == null) throw new DomainException("Vehicle: set-BrandModel: NULL value");
                _brandModel = value;
            } 
        }
        public VehicleType Categorie { get; set; }
        public string? Color 
        {
            get { return _color; }
            set { if (value == null) throw new DomainException("Vehicle: set-Color: NULL value");
            _color = value;
            } 
        }
        public int? Doors 
        {
            get { return _doors; }
            set
            {
                if (value == null) throw new DomainException("Vehicle: set-Doors: NULL value");
                _doors = (int)value;
            }
        }
        public FuelType Fuel { get; set; }

        public Driver? Driver { get; set; }
    }
}
