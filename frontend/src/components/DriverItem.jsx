import { NavLink } from 'react-router-dom';
import classes from '../css/Detail.module.css';
import foto from '../images/user.png';
import DetailCard from './DetailCard';

const DriverItem = ({ driver }) => {
  return (
    <>
      <DetailCard type="driver" id={driver.driverID}>
        <article>
          <div className={classes.table}>
            <div className={classes.title}>
              {driver.firstName} {driver.lastName}
            </div>
            <div className={classes.image}>
              <img
                src={foto}
                alt={`Foto van ${driver.firstName} ${driver.lastName}`}
              />
            </div>
            <div className={classes.data}>
              <p>Geboortedatum: {driver.birthDate.split('T', 1)}</p>
              <p>Rijksregisternummer: {driver.natRegNum}</p>
              <p>Adres: {driver.address}</p>
              <p>Rijbewijs: {driver.licenses.toString()}</p>
              {driver.vehicleLicensePlate && (
                <p>
                  Nummerplaat:{' '}
                  <NavLink to={`/vehicles/${driver.vehicleVin}`}>
                    {driver.vehicleLicensePlate}
                  </NavLink>
                </p>
              )}
              {driver.gasCardNum && (
                <p>
                  Tankkaart:{' '}
                  <NavLink to={`/gascards/${driver.gasCardNum}`}>
                    {driver.gasCardNum}
                  </NavLink>
                </p>
              )}
            </div>
          </div>
        </article>
      </DetailCard>
    </>
  );
};

export default DriverItem;
