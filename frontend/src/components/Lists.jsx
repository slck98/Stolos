import React from 'react';
import { Link } from 'react-router-dom';
import vehicleClasses from '../css/VehicleList.module.css';
import driverClasses from '../css/DriverList.module.css';
import gasCardClasses from '../css/GascardList.module.css';
import logo from '../images/logoLong.png';

const DriverList = ({ drivers }) => {
  return (
    <header className={driverClasses.container}>
      <article className={driverClasses.headerPage}>
        <h1>Bestuurders</h1>
        <img src={logo} alt="logo"></img>
      </article>

      <hr className={driverClasses.line} />
      <ul>
        {drivers.map(driver => (
          <li key={driver.driverID.toString()}>
            <Link to={driver.driverID.toString()}>{driver.firstName}</Link>
          </li>
        ))}
      </ul>
    </header>
  );
};

export const VehicleList = ({ vehicles }) => {
  return (
    <header className={vehicleClasses.container}>
      <article className={vehicleClasses.headerPage}>
        <h1>Voertuigen</h1>
        <img src={logo} alt="logo"></img>
      </article>

      <hr className={vehicleClasses.line} />
      <ul>
        {vehicles.map(vehicle => (
          <li key={vehicle.vin}>
            <Link to={vehicle.vin}>{vehicle.licensePlate}</Link>
          </li>
        ))}
      </ul>
    </header>
  );
};

export const GascardList = ({ gascards }) => {
  return (
    <header className={gasCardClasses.container}>
      <article className={gasCardClasses.headerPage}>
        <h1>Brandstofkaarten</h1>
        <img src={logo} alt="logo" />
      </article>

      <hr className={gasCardClasses.line} />
      <ul>
        {gascards.map(gascard => (
          <li key={gascard.cardNumber.toString()}>
            <Link to={gascard.cardNumber.toString()}>{gascard.cardNumber}</Link>
          </li>
        ))}
      </ul>
    </header>
  );
};
export default DriverList;
