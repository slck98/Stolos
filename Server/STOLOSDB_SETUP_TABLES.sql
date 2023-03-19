/* DROP IF EXISTS*/
DROP TABLE IF EXISTS Driver;
DROP TABLE IF EXISTS Vehicle;
DROP TABLE IF EXISTS GasCard;

/* CREATE TABLES */
CREATE TABLE `Driver` (
	`ID` INT(255) NOT NULL AUTO_INCREMENT,
	`FirstName` VARCHAR(20) NOT NULL,
	`LastName` VARCHAR(20) NOT NULL,
	`Address` VARCHAR(50),
	`BirthDate` DATE NOT NULL,
	`NationalRegistrationNumber` VARCHAR(15) NOT NULL,
	`DriversLicenses` VARCHAR(41) NOT NULL,
	`GasCardID` INT(255),
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
	`DriverID` INT(255),
	`Deleted` INT(1) NOT NULL,
	PRIMARY KEY (`VIN`)
);
CREATE TABLE `GasCard` (
	`ID` INT(255) NOT NULL AUTO_INCREMENT,
	`CardNumber` VARCHAR(20) NOT NULL,
	`ExpiringDate` DATE NOT NULL,
	`Pincode` INT(4),
	`FuelType` VARCHAR(100),
	`DriverID` INT(255),
	`Blocked` INT(1) NOT NULL,
	`Deleted` INT(1) NOT NULL,
	PRIMARY KEY (`ID`)
);

/* ADD CONSTRAINTS*/
/* FK */
ALTER TABLE Driver ADD CONSTRAINT fk_driver_gascardid_gascardid FOREIGN KEY (GascardID) REFERENCES GasCard(ID) ON DELETE SET NULL;
ALTER TABLE Driver ADD CONSTRAINT fk_driver_vehiclevin_vehiclevin FOREIGN KEY (VehicleVIN) REFERENCES Vehicle(VIN) ON DELETE SET NULL;
ALTER TABLE Vehicle ADD CONSTRAINT fk_vehicle_driverid_driverid FOREIGN KEY (DriverID) REFERENCES Driver(ID) ON DELETE SET NULL;
ALTER TABLE GasCard ADD CONSTRAINT fk_gascard_driverid_driverid FOREIGN KEY (DriverID) REFERENCES Driver(ID) ON DELETE SET NULL;

/* UQ */
ALTER TABLE Driver ADD CONSTRAINT uc_driver_natregnum UNIQUE (NationalRegistrationNumber);
ALTER TABLE Driver ADD CONSTRAINT uc_driver_vehiclevin UNIQUE (VehicleVIN);
ALTER TABLE Driver ADD CONSTRAINT uc_driver_tankcardid UNIQUE (GasCardID);

ALTER TABLE Vehicle ADD CONSTRAINT uc_vehicle_licenseplate UNIQUE (LicensePlate);
ALTER TABLE Vehicle ADD CONSTRAINT uc_vehicle_driverid UNIQUE (DriverID);


ALTER TABLE GasCard ADD CONSTRAINT uc_gascard_cardnum UNIQUE (CardNumber);
ALTER TABLE GasCard ADD CONSTRAINT uc_gascard_driverid UNIQUE (DriverID);

/* CHK */
ALTER TABLE Driver ADD CONSTRAINT chk_natregnum CHECK (((97-MOD(concat(substring(NationalRegistrationNumber, 1, 2), substring(NationalRegistrationNumber, 4, 2), substring(NationalRegistrationNumber, 7, 2), substring(NationalRegistrationNumber, 10, 3)), 97))=substring(NationalRegistrationNumber, 14, 2)) OR ((97-MOD(concat(2, substring(NationalRegistrationNumber, 1, 2), substring(NationalRegistrationNumber, 4, 2), substring(NationalRegistrationNumber, 7, 2), substring(NationalRegistrationNumber, 10, 3)), 97)=substring(NationalRegistrationNumber, 14, 2))));


/* To drop tables: DROP TABLE Driver, Vehicle, GasCard; */
