import '../css/Button.css';

const Button = props => {
    return(
        <div class='button'>
            <a href="#" className="bestuurders">
                <p>BESTUURDERS</p>
            </a>
            <a href="#" className="voertuigen">
                <p>VOERTUIGEN</p>
            </a>
            <a href="#" className="tankkaarten">
                <p>TANKKAARTEN</p>
            </a>
        </div>
    )
}

export default Button;