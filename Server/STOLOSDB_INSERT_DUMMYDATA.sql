/* INSERT INTO TESTS */
INSERT INTO Driver(ID, FirstName, LastName, Address, BirthDate, NationalRegistrationNumber, DriversLicenses, GascardID, VehicleVIN, Deleted) VALUES (1, 'John', 'Doe', '123 Lexington Av., NYC, NY, USA', CURDATE(), '85.12.31-123.12', 'AM,B,C1E', NULL, NULL, 0);
INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('0123456789ABCDEFG', 'VW Polo', '1-ABC-123', 1, 1, NULL, NULL, NULL, 0);
INSERT INTO GasCard (ID, CardNumber, ExpiringDate, Pincode, FuelType, DriverID, Blocked, Deleted) VALUES (1, '1234567890ABCDEFGHIJ', '2024-12-31', 1234, 'Benzine,Diesel,Elektrisch', NULL, 0, 0);

/*
/* INSERT TESTS (CONSTRAINT TESTS) */
INSERT INTO Driver (FirstName, LastName, BirthDate, NationalRegistrationNumber, DriversLicenses, GasCardID, VehicleVIN, DELETED) VALUES ('John', 'Briggs', '2002-09-09', '85.12.31-123.12', 'AM,B', 1, '0123456789ABCDEFG', 0); /*UNIQUE NatRegNum*/
INSERT INTO Vehicle (VIN, BrandModel, LicensePlate, FuelType, VehicleType, Color, Doors, DriverID, Deleted) VALUES ('0123456789ABCDEFF', 'VW Polo', '1-ABC-123', 1, 1, NULL, NULL, NULL, 0);/*UNIQUE LicensePlate (VIN=PK=GUARANTEED UNQUE)*/
INSERT INTO GasCard (CardNumber, ExpiringDate, FuelType, DriverID, Blocked, Deleted) VALUES ('1234567890ABCDEFGHIJ', '2024-12-31', 'Benzine,Diesel,Elektrisch', NULL, 1, 1);/*UNIQUE CardNum*/
*/