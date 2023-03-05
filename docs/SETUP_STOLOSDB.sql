/* DROP IF EXISTS*/
DROP TABLE IF EXISTS Driver;
DROP TABLE IF EXISTS Vehicle;
DROP TABLE IF EXISTS Tankcard;

/* CREATE TABLES */
CREATE TABLE `Driver` (
	`ID` INT(10) NOT NULL AUTO_INCREMENT,
	`FirstName` VARCHAR(20) NOT NULL,
	`LastName` VARCHAR(20) NOT NULL,
	`Address` VARCHAR(50),
	`BirthDate` DATE NOT NULL,
	`NationalRegistrationNumber` VARCHAR(15) NOT NULL,
	`DriversLicenses` VARCHAR(41) NOT NULL,
	`TankcardID` INT,
	`VehicleVIN` VARCHAR(17),
	`Deleted` INT(1) NOT NULL,
	PRIMARY KEY (`ID`)
);
CREATE TABLE `Vehicle` (
	`VIN` VARCHAR(17) NOT NULL,
	`BrandModel` VARCHAR(50) NOT NULL,
	`NumberPlate` VARCHAR(25) NOT NULL,
	`FuelType` INT(10) NOT NULL,
	`VehicleType` INT(10) NOT NULL,
	`Color` VARCHAR(25),
	`Doors` INT(10),
	`DriverID` INT(10),
	`Deleted` INT(1) NOT NULL,
	PRIMARY KEY (`VIN`)
);
CREATE TABLE `Tankcard` (
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
ALTER TABLE Driver ADD CONSTRAINT fk_drivertankcardid_tankcardid FOREIGN KEY (TankcardID) REFERENCES Tankcard(ID) ON DELETE SET NULL;
ALTER TABLE Driver ADD CONSTRAINT fk_drivervehiclevin_vehiclevin FOREIGN KEY (VehicleVIN) REFERENCES Vehicle(VIN) ON DELETE SET NULL;

ALTER TABLE Vehicle ADD CONSTRAINT fk_vehicledriverid_driverid FOREIGN KEY (DriverID) REFERENCES Driver(ID) ON DELETE SET NULL;

ALTER TABLE Tankcard ADD CONSTRAINT fk_tankcarddriverid_driverid FOREIGN KEY (DriverID) REFERENCES Driver(ID) ON DELETE SET NULL;

/*
/* INSERT INTO TESTS */
INSERT INTO Driver(ID, FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, TankCardID, VehicleVIN, Deleted) VALUES (1, 'John', 'Doe', '123 Lexington Av., NYC, NY, USA', CURDATE(), '85.12.31-123.12', 'AM,B,C1E', NULL, NULL, 0);
INSERT INTO Vehicle (VIN, BrandModel, NumberPlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('0123456789ABCDEFG', 'VW Polo', '1-ABC-123', 1, 1, NULL, NULL, NULL, 0);
INSERT INTO Tankcard (ID, CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES (1, '1234567890ABCDEFGHIJ', '2024-12-31', 1234, '1,3,4', NULL, 0, 0);
/*
/* To drop tables: DROP TABLE Driver, Vehicle, Tankcard; */