import React, { useState } from 'react';
import foto from '../images/notAvailable.png';
import EditCard from './EditCard';
import classes from '../css/Edit.module.css';

const VehicleEdit = ({ vehicle }) => {
  const [input, setInput] = useState();

  const changeHandler = e => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };

  return (
    <EditCard>
      <form className={classes.table}>
        <img src={foto} alt="notAvailable" />
        <div className={classes.data}>
          <p>Model:</p>
          <input
            type="text"
            name="brandmodel"
            defaultValue={vehicle.brandModel}
            onChange={changeHandler}
          />
          <p>Kenteken:</p>
          <input
            type="text"
            name="licenseplate"
            defaultValue={vehicle.licensePlate}
            onChange={changeHandler}
          />
          <p>Chassisnummer:</p>
          <input
            type="text"
            name="vin"
            defaultValue={vehicle.vin}
            onChange={changeHandler}
          />
          <p>Type:</p>
          <input
            type="text"
            name="vehicletype"
            defaultValue={vehicle.vehicleType}
            onChange={changeHandler}
          />
          <p>Brandstof:</p>
          <input
            type="text"
            name="fueltype"
            defaultValue={vehicle.fuelType}
            onChange={changeHandler}
          />
          <p>Kleur:</p>
          <input
            type="text"
            name="color"
            defaultValue={vehicle.color}
            onChange={changeHandler}
          />
          <p>Aantal deuren:</p>
          <input
            type="text"
            name="doors"
            defaultValue={vehicle.doors}
            onChange={changeHandler}
          />
        </div>
      </form>
    </EditCard>
  );
};

export default VehicleEdit;
