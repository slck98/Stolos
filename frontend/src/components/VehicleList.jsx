import React from "react";
import { Link } from "react-router-dom";
import classes from "../css/VehicleList.module.css";
import logo from "../images/logoLong.png";

const VehicleList = ({ vehicles }) => {

  return (
    <article className={classes.container}>
      <article className={classes.headerPage}>
        <h1>Voertuigen</h1>
        <img src={logo} alt="logo"></img>
      </article>

      <hr className={classes.line} />
      <ul>
        {vehicles.map((vehicle) => (
          <li key={vehicle.vinNumber}>
            <Link to={vehicle.vinNumber}>{vehicle.licensePlate}</Link>
          </li>
        ))}
      </ul>
    </article>
  );
};

export default VehicleList;
