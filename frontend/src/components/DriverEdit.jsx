import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import foto from "../images/user.png";
import classes from "../css/DriverEdit.module.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBan, faFloppyDisk } from "@fortawesome/free-solid-svg-icons";

const DriverEdit = ({ driver }) => {
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
          <td>Naam:</td>
          <td>
            <input
              type="text"
              name="firstName"
              defaultValue={driver.firstName}
              onChange={changeHandler}
            />
          </td>
        </tr>
        <tr>
          <td>Familienaam:</td>
          <td>
            <input
              type="text"
              name="lastName"
              defaultValue={driver.lastName}
              onChange={changeHandler}
            />
          </td>
        </tr>
        <tr>
          <td>Geboortedatum:</td>
          <td>
            <input
              type="text"
              name="birthDate"
              defaultValue={driver.birthDate}
              onChange={changeHandler}
            />
          </td>
        </tr>
        <tr>
          <td>Rijksregisternummer:</td>
          <td>
            <input
              type="text"
              name="natRegNumber"
              defaultValue={driver.natRegNum}
              onChange={changeHandler}
            />
          </td>
        </tr>
        <tr>
          <td>Adres:</td>
          <td>
            <input
              type="text"
              name="address"
              defaultValue={driver.address}
              onChange={changeHandler}
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

export default DriverEdit;
