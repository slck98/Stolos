import '../css/Header.css';
import logo from '../logo.svg';

const Header = props => {
    return(
        <header className='header'>
            <img src={logo} alt="logo" />
            <h1>Fleet Management</h1>
        </header>
    )
}
export default Header;