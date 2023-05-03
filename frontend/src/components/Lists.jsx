import React from 'react';
import { Link } from 'react-router-dom';
import vehicleClasses from '../css/VehicleList.module.css';
import driverClasses from '../css/DriverList.module.css';
import gasCardClasses from '../css/GascardList.module.css';
import logo from '../images/logoLong.png';
import { faEye, faPen } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

const DriverList = ({ drivers }) => {
  return (
    <header className={driverClasses.container}>
      <article className={driverClasses.headerPage}>
        <img src={logo} alt="logo"></img>
        <h1>BESTUURDERS</h1>
        <img src={logo} alt="logo"></img>
      </article>
      <hr className={driverClasses.line} />
      <ul className={driverClasses.columns}>
        {drivers.map(driver => (
          <li key={driver.driverID.toString()}>
            <Link to={driver.driverID.toString()}>
              {driver.firstName} {driver.lastName} 
              <span>
                <FontAwesomeIcon title='bekijken' className={driverClasses.eye} icon={faEye} />&nbsp;&nbsp;&nbsp;|
                <Link className={driverClasses.update} to={`/drivers/${driver.driverID}/edit`}><FontAwesomeIcon title='bewerken' icon={faPen}/></Link>
              </span>
            </Link>
            
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
      <img src={logo} alt="logo"></img>
        <h1>VOERTUIGEN</h1>
        <img src={logo} alt="logo"></img>
      </article>

      <hr className={vehicleClasses.line} />
      <ul className={vehicleClasses.columns}>
        {vehicles.map(vehicle => (
          <li key={vehicle.vin}>
            <Link to={vehicle.vin}>
              {vehicle.licensePlate}
              <span>
                <FontAwesomeIcon title='bekijken' className={vehicleClasses.eye} icon={faEye} />&nbsp;&nbsp;&nbsp;|
                <Link className={vehicleClasses.update} to={`/vehicles/${vehicle.vin}/edit`}><FontAwesomeIcon title='bewerken' icon={faPen}/></Link>
              </span>
            </Link>
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
        <img src={logo} alt="logo"></img>
        <h1>BRANDSTOFKAARTEN</h1>
        <img src={logo} alt="logo" />
      </article>

      <hr className={gasCardClasses.line} />
      <ul className={gasCardClasses.columns}>
        {gascards.map(gascard => (
          <li key={gascard.cardNumber.toString()}>
            <Link to={gascard.cardNumber.toString()}>
              {gascard.cardNumber}
              <span>
                <FontAwesomeIcon title='bekijken' className={gasCardClasses.eye} icon={faEye} />&nbsp;&nbsp;&nbsp;|
                <Link className={gasCardClasses.update} to={`/gascards/${gascard.cardNumber}/edit`}><FontAwesomeIcon title='bewerken' icon={faPen}/></Link>
              </span>
            </Link>
          </li>
        ))}
      </ul>
    </header>
  );
};
export default DriverList;
