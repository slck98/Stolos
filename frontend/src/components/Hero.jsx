import '../css/Hero.css';
import logo from '../logoShort.png';

const Hero = props => {
  return (
    <header className="header">
      <div>
        <img src={logo} alt="logo" />
      </div>
      <div>
        <h1>FLEET MANAGEMENT</h1>
        <h2>Klik op een knop om te starten</h2>
      </div>
    </header>
  );
};
export default Hero;
