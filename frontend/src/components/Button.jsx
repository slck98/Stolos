import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCar } from '@fortawesome/free-solid-svg-icons';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { faGasPump } from '@fortawesome/free-solid-svg-icons';
import '../css/Button.css';


const Button = props => {
  return (
    <div className="button">
      <Link to="drivers" className="bestuurders">
        <p><FontAwesomeIcon icon={faUser} /> BESTUURDERS</p>
      </Link>
      <Link to="vehicles" className="voertuigen">
        <p><FontAwesomeIcon icon={faCar} /> VOERTUIGEN</p>
      </Link>
      <Link to="gascards" className="tankkaarten">
        <p><FontAwesomeIcon icon={faGasPump}/> TANKKAARTEN</p>
      </Link>
    </div>
  );
};

export default Button;
