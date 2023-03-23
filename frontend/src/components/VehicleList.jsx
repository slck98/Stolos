import React from 'react';
import { Link } from 'react-router-dom';

const VehicleList = ({ vehicles }) => {
  return (
    <ul>
      {vehicles.map(vehicle => (
        <li key={vehicle.vinNumber}>
          <Link to={vehicle.vinNumber}>{vehicle.licensePlate}</Link>
        </li>
      ))}
    </ul>
  );
};

export default VehicleList;
