import React, { useState } from 'react';
import foto from '../images/user.png';
import classes from '../css/Edit.module.css';
import EditCard from './EditCard';

const DriverEdit = ({ driver }) => {
  const [input, setInput] = useState();

  const changeHandler = e => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };

  return (
    <>
      <EditCard>
        <form className={classes.table}>
          <img src={foto} alt="notAvailable" />
          <div className={classes.data}>
            <p>Naam:</p>
            <input
              type="text"
              name="firstName"
              defaultValue={driver.firstName}
              onChange={changeHandler}
            />
            <p>Familienaam:</p>
            <input
              type="text"
              name="lastName"
              defaultValue={driver.lastName}
              onChange={changeHandler}
            />
            <p>Geboortedatum:</p>
            <input
              type="text"
              name="birthDate"
              defaultValue={driver.birthDate}
              onChange={changeHandler}
            />
            <p>Rijksregisternummer:</p>
            <input
              type="text"
              name="natRegNumber"
              defaultValue={driver.natRegNum}
              onChange={changeHandler}
            />
            <p>Adres:</p>
            <input
              type="text"
              name="address"
              defaultValue={driver.address}
              onChange={changeHandler}
            />
          </div>
        </form>
      </EditCard>
    </>
  );
};

export default DriverEdit;
