import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import classes from '../css/DriverItem.module.css';
import foto from '../images/user.png';
import DeletePopup from './DeletePopup';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPen,faTrashCan} from '@fortawesome/free-solid-svg-icons';

const DriverItem = ({ driver }) => {
  const [deletePopup, setDeletePopup] = useState(false);

  const navigate = useNavigate();

  return (
    <>
      <header className={classes.container}>
        <article className={classes.back}>
          <p onClick={() => navigate(-1)}>Terug</p>
        </article>
        <img src={foto} alt="User" />
          <table className={classes.one}>
            <tr>
              <th colSpan="2">{driver.firstName} {driver.lastName}</th>
            </tr>
            <tr>
              <td>Geboortedatum: </td>
              <td> {driver.birthDate}</td>
            </tr>
            <tr>
              <td>Rijksregisternummer: </td>
              <td> {driver.natRegNum}</td>
            </tr>
            <tr>
              <td>Adres: </td>
              <td> {driver.address}</td>
            </tr>
            <tr>
              <td>License: </td>
              <td> {driver.licenses}</td>
            </tr>
          </table>

        <article className={classes.button}>
          <p onClick={() => navigate(`/drivers/${driver.driverID}/edit`)} className={classes.bewerken}>
          <FontAwesomeIcon icon={faPen}/> Bewerken
          </p>
          <p onClick={() => setDeletePopup(true)} className={classes.verwijderen}><FontAwesomeIcon icon={faTrashCan}/> Verwijderen</p>
        </article>

        {/* <article className={classes.three}>
          <h3>Alle Voertuigen</h3>

          <ul>
            <li></li>
          </ul>
        </article> */}
      </header>

      <DeletePopup trigger={deletePopup} setTrigger={setDeletePopup}>
        <p>Zeker dat u deze bestuurder wilt verwijderen?</p>
      </DeletePopup>
    </>
  );
};

export default DriverItem;
