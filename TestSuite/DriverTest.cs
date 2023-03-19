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
            Assert.Throws<DomainException>(() => new Driver(1, null, null, null, null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void TestDriver_InvalidId_ThrowException(int id) {
            List<DriversLicense> licenses = new List<DriversLicense>();
            licenses.Add(DriversLicense.B);
            Assert.Throws<DomainException>(() => new Driver(id, "voornaam", "achternaam", "75.10.23-059.39", licenses));
            //Driver d = new Driver(1, "voornaam", "achternaam", geboortedatum, "75.10.23-059.39", licenses);
            //Assert.Equal(1, d.Id);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TestDriver_InvalidFirstName_ThrowException(string firstname) {
            List<DriversLicense> licenses = new List<DriversLicense>();
            licenses.Add(DriversLicense.B);
            Assert.Throws<DomainException>(() => new Driver(1, firstname, "achternaam", "75.10.23-059.39", licenses));
        }

        //TODO: Extract birthdate from RRN then this test can be refactored to check if Birthdate == birthdate in RRN
        /* [Fact]
        public void TestDriver_InvalidBirthDateToRRN_ThrowException() {
            DateTime geboortedatum = new DateTime(1976, 10, 23);
            List<DriversLicense> licenses = new List<DriversLicense>();
            licenses.Add(DriversLicense.B);
            Assert.Throws<DomainException>(() => new Driver(1, "voornaam", "achternaam", geboortedatum, "75.10.23-059.39", licenses));
        }
        */

        [Theory]
        [InlineData(null)]
        // [InlineData("0.0.0-000.00")] // TODO: this should not work
        // [InlineData("00.00.00-000.00")] // TODO: this should not work
        public void TestDriver_InvalidRRN_ThrowException(string rrn) {
            List<DriversLicense> licenses = new List<DriversLicense>();
            licenses.Add(DriversLicense.B);
            Assert.Throws<DomainException>(() => new Driver(1, "voornaam", "achternaam", rrn, licenses));
        }
    }
}
