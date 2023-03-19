using BusinessLayer.Model;
using BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite {
    public class DriverTest {
        [Fact]
        public void TestDriver_NullValuesForFields_ThrowExcepion() {
            Assert.Throws<DomainException>(() => new Driver(1, null, null, new DateTime(), null, null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void TestDriver_InvalidId_ThrowException(int id) {
            DateTime geboortedatum = new DateTime(1975, 10, 23);
            List<DriversLicense> licenses = new List<DriversLicense>();
            licenses.Add(DriversLicense.B);
            Assert.Throws<DomainException>(() => new Driver(id, "voornaam", "achternaam", geboortedatum, "75.10.23-059.39", licenses));
            //Driver d = new Driver(1, "voornaam", "achternaam", geboortedatum, "75.10.23-059.39", licenses);
            //Assert.Equal(1, d.Id);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TestDriver_InvalidFirstName_ThrowException(string firstname) {
            DateTime geboortedatum = new DateTime(1975, 10, 23);
            List<DriversLicense> licenses = new List<DriversLicense>();
            licenses.Add(DriversLicense.B);
            Assert.Throws<DomainException>(() => new Driver(1, firstname, "achternaam", geboortedatum, "75.10.23-059.39", licenses));
        }
    }
}
