import React from 'react';
import classes from '../css/DriverList.module.css';
import logo from '../images/logoLong.png';
import { Link } from 'react-router-dom';

const DriverList = ({ drivers }) => {
  return (
    <article className={classes.container}>
      <article className={classes.headerPage}>
        <h1>Bestuurders</h1>
        <img src={logo} alt="logo"></img>
      </article>

      <hr className={classes.line} />
      <ul>
        {drivers.map(driver => (
          <li key={driver.driverID}>
            <Link to={driver.driverID}>{driver.firstName}</Link>
          </li>
        ))}
      </ul>
    </article>
  );
};

export default DriverList;
