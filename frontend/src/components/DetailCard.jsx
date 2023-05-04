import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faCircleArrowLeft,
  faTrashCan,
  faPen,
} from '@fortawesome/free-solid-svg-icons';
import DeletePopup from './DeletePopup';
import classes from '../css/DetailCard.module.css';

const DetailCard = props => {
  const [deletePopup, setDeletePopup] = useState(false);
  const navigate = useNavigate();

  return (
    <section className={classes.container}>
      {props.children}
      <div className={classes.buttons}>
        <button className={classes.back} onClick={() => navigate(-1)}>
          <FontAwesomeIcon icon={faCircleArrowLeft} /> Terug
        </button>
        <button
          onClick={() => navigate(`/${props.type}s/${props.id}/edit`)}
          className={classes.edit}
        >
          <FontAwesomeIcon icon={faPen} /> Bewerken
        </button>
        <button onClick={() => setDeletePopup(true)} className={classes.delete}>
          <FontAwesomeIcon icon={faTrashCan} /> Verwijderen
        </button>
      </div>
      <DeletePopup trigger={deletePopup} setTrigger={setDeletePopup}>
        <p>Bent u zeker dat u dit item wil verwijderen?</p>
      </DeletePopup>
    </section>
  );
};

export default DetailCard;
