import '../css/StartScreen.css';
import Hero from '../components/Hero';
import Button from '../components/Button.jsx';

const StartPage = props => {
  return (
    <div className="startscreen">
      <Hero />
      <Button />
    </div>
  );
};

export default StartPage;
