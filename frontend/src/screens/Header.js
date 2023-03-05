import '../css/Header.css';
import logo from '../logo.png';

const Header = props => {
    return(
        <header className='header'>
            <div>
                <img src={logo} alt="logo" />
            </div>
            <div>
                <h1>FLEET MANAGEMENT</h1>
                <h2>Klik op een knop om te starten</h2>
            </div>
            
        </header>
    )
}
export default Header;