import DetailCard from "./DetailCard";
import { NavLink } from "react-router-dom";
import classes from "../css/Detail.module.css";
import foto from "../images/notAvailable.png";

const VehicleItem = ({ vehicle }) => {
  return (
    <>
      <DetailCard type="vehicle" id={vehicle.vin}>
        <article>
          <div className={classes.table}>
            <div className={classes.title}>{vehicle.brandModel}</div>
            <div className={classes.image}>
              <img src={foto} alt={`Foto van ${vehicle.brandModel}`} />
            </div>
            <div className={classes.data}>
              <p>Kenteken: {vehicle.licensePlate}</p>
              <p>Chassisnummer: {vehicle.vin}</p>
              <p>Type: {vehicle.vehicleType}</p>
              <p>Brandstof: {vehicle.fuelType}</p>
              <p>Kleur: {vehicle.color}</p>
              <p>Aantal deuren: {vehicle.doors}</p>
              {vehicle.driverId && (
                <p>
                  Bestuurder: 
                   <NavLink to={`/drivers/${vehicle.driverId}`}>
                      {vehicle.driverId}
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

export default VehicleItem;
