import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import foto from '../images/user.png';
import classes from '../css/DriverEdit.module.css';

const DriverEdit = ({ driver }) => {
  const [input, setInput] = useState();
  const navigate = useNavigate();

  const changeHandler = e => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };

  return (
    <article className={classes.container}>
      <img src={foto} alt="notAvailable" />
      <article className={classes.one}>
        <span>
          <p>Naam:</p>
          <input
            type="text"
            name="firstName"
            defaultValue={driver.firstName}
            onChange={changeHandler}
          />
        </span>
        <span>
          <p>Familienaam:</p>
          <input
            type="text"
            name="lastName"
            defaultValue={driver.lastName}
            onChange={changeHandler}
          />
        </span>
        <span>
          <p>Geboortedatum:</p>
          <input
            type="text"
            name="birthDate"
            defaultValue={driver.birthDate}
            onChange={changeHandler}
          />
        </span>
        <span>
          <p>Rijksregisternummer:</p>
          <input
            type="text"
            name="natRegNumber"
            defaultValue={driver.natRegNum}
            onChange={changeHandler}
          />
        </span>
        <span>
          <p>Adres:</p>
          <input
            type="text"
            name="address"
            defaultValue={driver.address}
            onChange={changeHandler}
          />
        </span>        
      </article>
      <article className={classes.two}>
        <p onClick={() => navigate(-1)}>Opslaan</p>
        <p onClick={() => navigate(-1)}>Annuleren</p>
      </article>
    </article>
  );
};

export default DriverEdit;
