# Readme voor het fleetmanagement voor AllPhi

## Backend API Requests

### Driver

- /Driver (GET)
  - Geen waarden of object nodig
- /Driver (POST)
  - Firstname
  - Lastname
  - Address
  - BirthDate
  - Nationalregistrationnumber
- /Driver (PUT)
  - Id
  - Firstname
  - Lastname
  - Address
  - BirthDate
  - Nationalregistrationnumber
- /Driver (DELETE)
  - Id
- /Driver/{id}
  - Id

### GasCard

- /GasCard (GET)
  - Geen waarden of object nodig
- /GasCard (POST)
  - Cardnumber
  - ExpiringDate
  - Pincode
  - Blocked
  - DriverId
  - An array of FuelTypes
- /GasCard (PUT)
  - Cardnumber
  - ExpiringDate
  - Pincode
  - Blocked
  - DriverId
  - An array of FuelTypes
- /GasCard (DELETE)
  - Cardnumber
- /GasCard/{cardnum}
  - Cardnumber

### Vehicle

- /Vehicle (GET)
  - Geen waarden of object nodig
- /Vehicle (POST)
  - Vinnumber
  - BrandModel
  - LicensePlate
  - Fueltype
  - VehicleType
  - Color
  - Doors
  - DriverId
- /Vehicle (PUT)
  - Vinnumber
  - BrandModel
  - LicensePlate
  - Fueltype
  - VehicleType
  - Color
  - Doors
  - DriverId
- /Vehicle (DELETE)
  - Vinnumber
- /Vehicle/{vin}
  - Vinnumber
