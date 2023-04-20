import { useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBan, faFloppyDisk } from '@fortawesome/free-solid-svg-icons';
import classes from '../css/EditCard.module.css';

const EditCard = props => {
  const navigate = useNavigate();
  return (
    <section className={classes.container}>
      {props.children}
      <div className={classes.buttons}>
        <button onClick={() => navigate(-1)} className={classes.save}>
          <FontAwesomeIcon icon={faFloppyDisk} /> Opslaan
        </button>
        <button onClick={() => navigate(-1)} className={classes.cancel}>
          <FontAwesomeIcon icon={faBan} /> Annuleren
        </button>
      </div>
    </section>
  );
};

export default EditCard;
