import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import classes from '../css/GascardEdit.module.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBan, faFloppyDisk } from '@fortawesome/free-solid-svg-icons';

const GascardEdit = ({ gascard }) => {
  const [input, setInput] = useState();
  const navigate = useNavigate();

  const changeHandler = e => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };

  return (
    <article className={classes.container}>
      <table className={classes.one}>
        <tbody>
          <tr>
            <td>Kaartnummer:</td>
            <td>
              <input
                type="text"
                name="cardNumber"
                defaultValue={gascard.cardNumber}
                readOnly
              />
            </td>
          </tr>
          <tr>
            <td>Vervaldatum:</td>
            <td>
              <input
                type="date"
                name="expiringDate"
                defaultValue={gascard.expiringDate}
                onChange={changeHandler}
              />
            </td>
          </tr>
          <tr>
            <td>Pincode:</td>
            <td>
              <input
                type="text"
                name="pincode"
                defaultValue={gascard.pincode.toString()}
                onChange={changeHandler}
              />
            </td>
          </tr>
          <tr>
            <td>Brandstoftypen:</td>
            <td>
              <input
                type="text"
                name="fuelTypes"
                defaultValue={gascard.fuelTypes.toString()}
                onChange={changeHandler}
              />
            </td>
          </tr>
          <tr>
            <td>Geblokkeerd:</td>
            <td>
              <select>
                <option value="true">Ja</option>
                <option value="false">Nee</option>
              </select>
            </td>
          </tr>
          <tr>
            <td>Gebruiker:</td>
            <td>
              <input
                type="text"
                name="user"
                defaultValue={
                  gascard.driver.firstName + ' ' + gascard.driver.lastName
                }
                onCHange={changeHandler}
              />
            </td>
          </tr>
        </tbody>
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

export default GascardEdit;
