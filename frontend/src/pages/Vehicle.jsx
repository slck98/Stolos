import React from 'react';
import { useLoaderData } from 'react-router-dom';
import VehicleList from '../components/VehicleList';

const VehiclePage = () => {
  const vehicles = useLoaderData();

  return <VehicleList vehicles={vehicles} />;
};

export default VehiclePage;

export const loadVehicles = async () => {
  const response = await fetch('https://localhost:7144/vehicle');
  const result = await response.json();
  return result;
};
