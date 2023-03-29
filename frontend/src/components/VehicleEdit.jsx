import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import foto from "../images/notAvailable.png";
import classes from "../css/VehicleEdit.module.css";

const VehicleEdit = ({ vehicle }) => {
  const [input, setInput] = useState();
  const navigate = useNavigate();

  const changeHandler = (e) => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };
  
  return (
    <article className={classes.container}>
      <img src={foto} alt="notAvailable" />
      <article className={classes.one}>
        <span>
          <p>Model:</p>
          <input
            type="text"
            name="brandModel"
            defaultValue={vehicle.brandModel}
            onChange={changeHandler}
          />
        </span>
        <span>
          <p>Kenteken:</p>
          <input
            type="text"
            name="licensePlate"
            defaultValue={vehicle.licensePlate}
            onChange={changeHandler}
          />
        </span>
        <span>
          <p>Chasisnummer:</p>
          <input
            type="text"
            name="vinNumber"
            defaultValue={vehicle.vinNumber}
            onChange={changeHandler}
          />
        </span>
        {/* <span>
                    <p>Brandstof:</p>
        <input type="text" name="fuel" defaultValue={vehicle.fuel} />
      </span> */}
        <span>
          <p>Kleur:</p>
          <input
            type="text"
            name="color"
            defaultValue={vehicle.color}
            onChange={changeHandler}
          />
        </span>
        <span>
          <p>Aantal deuren:</p>
          <input
            type="text"
            name="doors"
            defaultValue={vehicle.doors}
            readOnly
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

export default VehicleEdit;
