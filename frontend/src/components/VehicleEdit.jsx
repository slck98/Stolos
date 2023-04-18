import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import foto from "../images/notAvailable.png";
import classes from "../css/VehicleEdit.module.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBan, faFloppyDisk } from "@fortawesome/free-solid-svg-icons";

const VehicleEdit = ({ vehicle }) => {
  const [input, setInput] = useState();
  const navigate = useNavigate();

  const changeHandler = (e) => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };

  return (
    <article className={classes.container}>
      <img src={foto} alt="notAvailable" />
      <table className={classes.one}>
        <tr>
          <td>Model:</td>
          <td>
            <input
              type="text"
              name="brandModel"
              defaultValue={vehicle.brandModel}
              readOnly
            />
          </td>
        </tr>
        <tr>
          <td>Kenteken:</td>
          <td>
            <input
              type="text"
              name="licensePlate"
              defaultValue={vehicle.licensePlate}
              onChange={changeHandler}
            />
          </td>
        </tr>
        <tr>
          <td>Chassisnummer:</td>
          <td>
            <input type="text" name="vin" defaultValue={vehicle.vin} readOnly />
          </td>
        </tr>
        <tr>
          <td>Type:</td>
          <td>
            <input
              type="text"
              name="type"
              defaultValue={vehicle.vehicleType}
              readOnly
            />
          </td>
        </tr>
        <tr>
          <td>Brandstof:</td>
          <td>
            <input
              type="text"
              name="fuelType"
              defaultValue={vehicle.fuelType}
              readOnly
            />
          </td>
        </tr>
        <tr>
          <td>Kleur:</td>
          <td>
            <input
              type="text"
              name="color"
              defaultValue={vehicle.color}
              readOnly
            />
          </td>
        </tr>
        <tr>
          <td>Aantal deuren:</td>
          <td>
            <input
              type="number"
              name="doors"
              defaultValue={vehicle.doors.toString()}
              readOnly
            />
          </td>
        </tr>
      </table>
      <article className={classes.button}>
        <p onClick={() => navigate(-1)} className={classes.opslaan}>
          <FontAwesomeIcon icon={faFloppyDisk} /> Opslaan
        </p>
        <p onClick={() => navigate(-1)} className={classes.annuleren}>
          <FontAwesomeIcon icon={faBan} /> Annuleren
        </p>
      </article>
    </article>
  );
};

export default VehicleEdit;
