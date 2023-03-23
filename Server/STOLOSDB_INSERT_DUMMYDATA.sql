/* INSERT INTO TESTS */
INSERT INTO Driver(FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, Deleted) VALUES ('John', 'Doe', '123 Lexington Av., NYC, NY, USA', '1985-12-31', '85.12.31-123.40', 'AM,B,C1E', 0);

INSERT INTO Driver(FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, Deleted) VALUES ('Maarten', 'Smet', 'Sint-Denijs-Westrem', '1980-7-04', '80.07.04-457.85', 'AM,B', 0);
INSERT INTO Driver(FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, Deleted) VALUES ('Simon', 'Van Hoecke', 'Hamme', '1995-08-27', '95.08.27-097.77', 'AM,B,C1E,D1E', 0);
INSERT INTO Driver(FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, Deleted) VALUES ('Noah', 'De Kraene', 'Oostende', '1972-02-12', '72.02.12-113.83', 'AM,B,C1E', 0);
INSERT INTO Driver(FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, Deleted) VALUES ('Thomas', 'De Bruyne', 'Schaarbeek', '1992-01-15', '92.01.15-225.03', 'AM,B', 0);
INSERT INTO Driver(FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, Deleted) VALUES ('Wouter', 'Van Breeck', 'Zolder', '1963-09-21', '63.09.21-991.56', 'AM,B', 0);
INSERT INTO Driver(FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, Deleted) VALUES ('Alexander', 'Van Haver', 'Haver', '1999-09-09', '99.09.09-099.27', 'AM,B', 0);


INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('01234567890000000', 'VW Polo', '1-ABC-123', 1, 1, 'black', 3, NULL, 0);
INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('01234567890000001', 'Audi A3', '1-AUD-333', 1, 1, 'grey', 3, NULL, 0);
INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('01234567890000002', 'BMW M2', '2-BMW-251', 1, 1, 'black', 3, NULL, 0);
INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('01234567890000003', 'Renault Kangoo', '2-XVF-173', 2, 1, 'red', 5, NULL, 0);
INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('01234567890000004', 'Kia EV6', '1-AIK-667', 3, 1, 'cherry', 5, NULL, 0);
INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('01234567890000005', 'Tesla Model 3', '2-TXT-555', 3, 1, 'white', 5, NULL, 0);

INSERT INTO GasCard (CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES ('12345678900000000000', '2023-12-31', NULL, NULL, NULL, 0, 0);
INSERT INTO GasCard (CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES ('12345678900000000001', '2023-12-31', 5555, '1,3', NULL, 0, 0);
INSERT INTO GasCard (CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES ('12345678900000000002', '2024-12-31', 9876, '1,2', NULL, 0, 0);
INSERT INTO GasCard (CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES ('12345678900000000003', '2026-12-31', 1234, '1,2', NULL, 0, 0);
INSERT INTO GasCard (CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES ('12345678900000000004', '2026-12-31', 6336, '1,2,3', NULL, 0, 0);
INSERT INTO GasCard (CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES ('12345678900000000005', '2026-12-31', 9753, '3', NULL, 0, 0);
INSERT INTO GasCard (CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES ('12345678900000000006', '2026-12-31', NULL, '3', NULL, 0, 0);



/*
/* INSERT TESTS (CONSTRAINT TESTS) */
INSERT INTO Driver (FirstName, LastName, BirthDate, NationalRegistrationNumber, DriversLicenses, DELETED) VALUES ('John', 'Briggs', '1985-12-31', '85.12.31-123.12', 'AM,B', NULL, NULL, 0); /*UNIQUE NatRegNum*/
INSERT INTO Driver (FirstName, LastName, BirthDate, NationalRegistrationNumber, DriversLicenses, DELETED) VALUES ('John', 'Briggs', '1984-12-31', '85.12.31-123.12', 'AM,B', NULL, NULL, 0); /* CHK bdate <> date from natregnum */

INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('0123456789ABCDEFF', 'VW Polo', '1-ABC-123', 1, 1, NULL, NULL, NULL, 0);/*UNIQUE LicensePlate (VIN=PK=GUARANTEED UNQUE)*/

INSERT INTO GasCard (CardNumber, ExpiringDate, FuelType, DriverID, Blocked, Deleted) VALUES ('1234567890ABCDEFGHIJ', '2024-12-31', '1,2,3', NULL, 1, 1);/*UNIQUE CardNum*/
*/