import React from 'react';
import { useLoaderData } from 'react-router-dom';

const VehiclePage = () => {
  const vehicles = useLoaderData();
  console.log(vehicles);
  return (
    <ul>
      {vehicles.map(vehicle => (
        <li key={vehicle.vinNumber}>{vehicle.licensePlate}</li>
      ))}
    </ul>
  );
};

export default VehiclePage;

export const loadVehicles = async () => {
  const response = await fetch('https://localhost:7144/vehicle');
  const result = await response.json();
  return result;
};
