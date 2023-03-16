import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCar } from '@fortawesome/free-solid-svg-icons';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { faGasPump } from '@fortawesome/free-solid-svg-icons';
import classes from '../css/Button.module.css';


const Button = props => {
  return (
    <div className={classes.button}>
      <Link to="drivers" className={classes.bestuurders}>
        <p><FontAwesomeIcon icon={faUser} /> BESTUURDERS</p>
      </Link>
      <Link to="vehicles" className={classes.voertuigen}>
        <p><FontAwesomeIcon icon={faCar} /> VOERTUIGEN</p>
      </Link>
      <Link to="gascards" className={classes.tankkaarten}>
        <p><FontAwesomeIcon icon={faGasPump}/> TANKKAARTEN</p>
      </Link>
    </div>
  );
};

export default Button;
