import { Link } from 'react-router-dom';
import '../css/Button.css';

const Button = props => {
  return (
    <div className="button">
      <Link to="drivers" className="bestuurders">
        <p>BESTUURDERS</p>
      </Link>
      <Link to="vehicles" className="voertuigen">
        <p>VOERTUIGEN</p>
      </Link>
      <Link to="gascards" className="tankkaarten">
        <p>TANKKAARTEN</p>
      </Link>
    </div>
  );
};

export default Button;
