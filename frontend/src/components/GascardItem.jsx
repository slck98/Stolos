import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import classes from '../css/GascardItem.module.css';
import DeletePopup from './DeletePopup';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faPen,
  faTrashCan,
  faCircleArrowLeft,
} from '@fortawesome/free-solid-svg-icons';

const GascardItem = ({ gascard }) => {
  const [deletePopup, setDeletePopup] = useState(false);

  const navigate = useNavigate();
  return (
    <>
      <header className={classes.container}>
        <nav className={classes.back}>
          <button onClick={() => navigate(-1)}>
            <FontAwesomeIcon icon={faCircleArrowLeft} />
            Terug
          </button>
        </nav>
        <table className={classes.one}>
          <tr>
            <th colSpan="2">{gascard.cardNumber}</th>
          </tr>
          <tr>
            <td>Vervaldatum: </td>
            <td> {gascard.expiringDate}</td>
          </tr>
          <tr>
            <td>Pin: </td>
            <td>
              {gascard.pincode !== null ? gascard.pincode.toString() : 'N.V.T.'}
            </td>
          </tr>
          <tr>
            <td>Brandstoftypen: </td>
            <td> {gascard.fuelTypes.toString()}</td>
          </tr>
          <tr>
            <td>Geblokkeerd: </td>
            <td> {gascard.blocked === true ? 'Ja' : 'Nee'}</td>
          </tr>
          <tr>
            <td>Gebruiker: </td>
            <td>
              {gascard.driver !== null
                ? gascard.driver.firstName && gascard.driver.lastName
                : 'N.V.T.'}
            </td>
          </tr>
        </table>

        <article className={classes.button}>
          <p
            onClick={() => navigate(`/gascards/${gascard.gascardID}/edit`)}
            className={classes.bewerken}
          >
            <FontAwesomeIcon icon={faPen} /> Bewerken
          </p>
          <p
            onClick={() => setDeletePopup(true)}
            className={classes.verwijderen}
          >
            <FontAwesomeIcon icon={faTrashCan} /> Verwijderen
          </p>
        </article>
      </header>

      <DeletePopup trigger={deletePopup} setTrigger={setDeletePopup}>
        <p>Zeker dat u deze kaart wilt verwijderen?</p>
      </DeletePopup>
    </>
  );
};

export default GascardItem;
