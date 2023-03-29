import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import classes from '../css/DriverItem.module.css';
import foto from '../images/user.png';
import DeletePopup from './DeletePopup';

const DriverItem = ({ driver }) => {
  const [deletePopup, setDeletePopup] = useState(false);

  const navigate = useNavigate();

  return (
    <>
      <article className={classes.container}>
        <article className={classes.back}>
          <p onClick={() => navigate(-1)}>Terug</p>
        </article>
        <img src={foto} alt="User" />
        <article className={classes.one}>
          <h4>{driver.firstName} {driver.lastName}</h4>
          <p>Geboortedatum: {driver.birthDate}</p>
          <p>Rijksregisternummer: {driver.natRegNum}</p>
          <p>Adres: {driver.address}</p>
          <p>License: {driver.licenses}</p>
        </article>

        <article className={classes.two}>
          <p onClick={() => navigate(`/drivers/${driver.driverID}/edit`)}>
            Bewerken
          </p>
          <p onClick={() => setDeletePopup(true)}>Verwijderen</p>
        </article>

        {/* <article className={classes.three}>
          <h3>Alle Voertuigen</h3>

          <ul>
            <li></li>
          </ul>
        </article> */}
      </article>

      <DeletePopup trigger={deletePopup} setTrigger={setDeletePopup}>
        <p>Zeker dat u deze bestuurder wilt verwijderen?</p>
      </DeletePopup>
    </>
  );
};

export default DriverItem;
