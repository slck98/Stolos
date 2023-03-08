/* DROP IF EXISTS*/
DROP TABLE IF EXISTS Driver;
DROP TABLE IF EXISTS Vehicle;
DROP TABLE IF EXISTS GasCard;

/* CREATE TABLES */
CREATE TABLE `Driver` (
	`ID` INT(10) NOT NULL AUTO_INCREMENT,
	`FirstName` VARCHAR(20) NOT NULL,
	`LastName` VARCHAR(20) NOT NULL,
	`Address` VARCHAR(50),
	`BirthDate` DATE NOT NULL,
	`NationalRegistrationNumber` VARCHAR(15) NOT NULL,
	`DriversLicenses` VARCHAR(41) NOT NULL,
	`GasCardID` INT,
	`VehicleVIN` VARCHAR(17),
	`Deleted` INT(1) NOT NULL,
	PRIMARY KEY (`ID`)
);
CREATE TABLE `Vehicle` (
	`VIN` VARCHAR(17) NOT NULL,
	`BrandModel` VARCHAR(50) NOT NULL,
	`LicensePlate` VARCHAR(25) NOT NULL,
	`FuelType` INT(10) NOT NULL,
	`VehicleType` INT(10) NOT NULL,
	`Color` VARCHAR(25),
	`Doors` INT(10),
	`DriverID` INT(10),
	`Deleted` INT(1) NOT NULL,
	PRIMARY KEY (`VIN`)
);
CREATE TABLE `GasCard` (
	`ID` INT(10) NOT NULL AUTO_INCREMENT,
	`CardNumber` VARCHAR(20) NOT NULL,
	`ExpiringDate` DATE NOT NULL,
	`Pincode` INT(4),
	`FuelType` VARCHAR(100),
	`DriverID` INT(10),
	`Blocked` INT(1) NOT NULL,
	`Deleted` INT(1) NOT NULL,
	PRIMARY KEY (`ID`)
);

/* ADD CONSTRAINTS*/
ALTER TABLE Driver ADD CONSTRAINT fk_drivergascardid_gascardid FOREIGN KEY (GascardID) REFERENCES GasCard(ID) ON DELETE SET NULL;
ALTER TABLE Driver ADD CONSTRAINT fk_drivervehiclevin_vehiclevin FOREIGN KEY (VehicleVIN) REFERENCES Vehicle(VIN) ON DELETE SET NULL;

ALTER TABLE Vehicle ADD CONSTRAINT fk_vehicledriverid_driverid FOREIGN KEY (DriverID) REFERENCES Driver(ID) ON DELETE SET NULL;

ALTER TABLE GasCard ADD CONSTRAINT fk_gascarddriverid_driverid FOREIGN KEY (DriverID) REFERENCES Driver(ID) ON DELETE SET NULL;

/*
/* INSERT INTO TESTS */
INSERT INTO Driver(ID, FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, GascardID, VehicleVIN, Deleted) VALUES (1, 'John', 'Doe', '123 Lexington Av., NYC, NY, USA', CURDATE(), '85.12.31-123.12', 'AM,B,C1E', NULL, NULL, 0);
INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('0123456789ABCDEFG', 'VW Polo', '1-ABC-123', 1, 1, NULL, NULL, NULL, 0);
INSERT INTO GasCard (ID, CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES (1, '1234567890ABCDEFGHIJ', '2024-12-31', 1234, 'Benzine,Diesel,Elektrisch', NULL, 0, 0);
/*
/* To drop tables: DROP TABLE Driver, Vehicle, Gascard; */