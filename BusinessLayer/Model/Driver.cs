using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Model
{
    public partial class Driver
    {
        public Driver(string lastName, string firstName, DateTime birthDate, string natRegNumber, List<DriversLicense> licenses)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
            NatRegNumber = natRegNumber;
            Licenses = licenses;
        }

        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDate { get; private set; }
        public string NatRegNumber { get; private set; }
        public List<DriversLicense> Licenses { get; set; }
    }
}
