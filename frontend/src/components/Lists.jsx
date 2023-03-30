import React from 'react';
import { Link } from 'react-router-dom';
import vehicleClasses from '../css/VehicleList.module.css';
import driverClasses from '../css/DriverList.module.css';
import gasCardClasses from "../css/GascardList.module.css";
import logo from '../images/logoLong.png';

const DriverList = ({ drivers }) => {
    return (
      <article className={driverClasses.container}>
        <article className={driverClasses.headerPage}>
          <h1>Bestuurders</h1>
          <img src={logo} alt="logo"></img>
        </article>
  
        <hr className={driverClasses.line} />
        <ul>
          {drivers.map(driver => (
            <li key={driver.driverID.toString()}>
              {console.log(driver)}
              <Link to={driver.driverID.toString()}>{driver.firstName}</Link>
            </li>
          ))}
        </ul>
      </article>
    );
  };

export const VehicleList = ({ vehicles }) => {
  return (
    <article className={vehicleClasses.container}>
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
    </article>
  );
};


export const GascardList = ({ gascards }) => {
    return (
      <article className={gasCardClasses.container}>
        <article className={gasCardClasses.headerPage}>
          <h1>Brandstofkaarten</h1>
          <img src={logo} alt="logo" />
        </article>
  
        <hr className={gasCardClasses.line} />
        <ul>
          {gascards.map((gascard) => (
            <li key={gascard.gasCardID.toString()}>
              <Link to={gascard.gasCardID.toString()}>{gascard.cardNumber}</Link>
            </li>
          ))}
        </ul>
      </article>
    );
  };
export default DriverList;
