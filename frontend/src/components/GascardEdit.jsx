import React, { useState } from 'react';
import foto from '../images/user.png';
import classes from '../css/Edit.module.css';

import EditCard from './EditCard';

const GascardEdit = ({ gascard }) => {
  const [input, setInput] = useState();

  const changeHandler = e => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };

  return (
    <EditCard>
      <form className={classes.table}>
        <img src={foto} alt="notAvailable" />
        <div className={classes.data}>
          <p>Kaartnummer:</p>
          <input
            type="text"
            name="cardNumber"
            defaultValue={gascard.cardNumber}
            onChange={changeHandler}
            readOnly
          />
          <p>Pincode:</p>
          <input
            type="text"
            name="pincode"
            defaultValue={gascard.pincode}
            onChange={changeHandler}
          />
          <p>Brandstoftypes:</p>
          <input
            type="text"
            name="fueltypes"
            defaultValue={gascard.fuelTypes}
            onChange={changeHandler}
          />
          <p>Geblokkeerd:</p>
          <select>
            <option value="true">Ja</option>
            <option value="false">Nee</option>
          </select>
        </div>
      </form>
    </EditCard>
  );
};

export default GascardEdit;
