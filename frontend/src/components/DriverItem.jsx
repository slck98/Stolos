import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import classes from '../css/DriverItem.module.css';
import foto from '../images/user.png';
import DeletePopup from './DeletePopup';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faPen,
  faTrashCan,
  faCircleArrowLeft,
} from '@fortawesome/free-solid-svg-icons';

const DriverItem = ({ driver }) => {
  const [deletePopup, setDeletePopup] = useState(false);

  const navigate = useNavigate();

  return (
    <>
      <section className={classes.container}>
        <nav className={classes.back}>
          <button onClick={() => navigate(-1)}>
            <FontAwesomeIcon icon={faCircleArrowLeft} />
            Terug
          </button>
        </nav>
        <article>
          <div className={classes.table}>
            <div className={classes.one}>
              {driver.firstName} {driver.lastName}
            </div>
            <div className={classes.two}>
              <img src={foto} alt="User" />
            </div>
            <div className={classes.three}>
              Geboortedatum: {driver.birthDate.split('T', 1)}
            </div>
            <div className={classes.four}>
              Rijksregisternummer: {driver.natRegNum}
            </div>
            <div className={classes.five}>Adres: {driver.address}</div>
            <div className={classes.six}>
              Rijbewijs: {driver.licenses.toString()}
            </div>
            <div className={classes.seven}>
              Nummerplaat: {driver.vehicleLicensePlate}
            </div>
          </div>
        </article>

        <article className={classes.button}>
          <p
            onClick={() => navigate(`/drivers/${driver.driverID}/edit`)}
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
      </section>

      <DeletePopup trigger={deletePopup} setTrigger={setDeletePopup}>
        <p>Zeker dat u deze bestuurder wilt verwijderen?</p>
      </DeletePopup>
    </>
  );
};

export default DriverItem;
