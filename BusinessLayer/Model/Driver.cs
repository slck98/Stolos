using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Exceptions;

namespace BussinessLayer.Model
{
    public partial class Driver
    {
        private int _id;
        private string _lastName;
        private string _firstName;
        private string _address;
        private DateTime _birthDate;
        private string _natRegNumber;

        public Driver(string lastName, string firstName, DateTime birthDate, string natRegNumber, List<DriversLicense> licenses)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
            NatRegNumber = natRegNumber;
            Licenses = licenses;
        }

        public int Id 
        {
            get { return _id; } 
            set 
            { 
                if(value == null) throw new DomainException("Driver: set-Id: NULL value");
                _id = value;
            }
        }
        public string LastName 
        {
            get { return _lastName; }
            set
            {
                if (value == null) throw new DomainException("Driver: set-LastName: NULL value;");
                _lastName = value;
            } 
        }
        public string FirstName 
        {
            get { return _firstName; }
            set
            {
                if (value == null) throw new DomainException("Driverr: set-FirstName: NULL value");
                _firstName = value;
            }
        }
        public string? Address 
        {
            get { return _address; }
            set
            {
                if (value == null) throw new DomainException("Driver: set-Address: NULL value");
                _address = value;
            }
        }
        public DateTime BirthDate 
        {
            get { return _birthDate; }
            set
            {
                if (value == default(DateTime)) throw new DomainException("Driver: set-BirthDate: NULL value");
                _birthDate = value;
            }
        }
        public string NatRegNumber 
        {
            get { return _natRegNumber; }
            set
            {
                if (value == null) throw new DomainException("Driver: set-NatRegNumber: NULL value");
                _natRegNumber = value;
            }
        }
        public List<DriversLicense> Licenses { get; set; }
    }
}
