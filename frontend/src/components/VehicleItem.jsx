import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import classes from "../css/VehicleItem.module.css";
import foto from "../images/notAvailable.png";
import DeletePopup from "./DeletePopup";

const VehicleItem = ({ vehicle }) => {
  const [deletePopup, setDeletePopup] = useState(false);

  const navigate = useNavigate();

  return (
    <>
      <article className={classes.container}>
        <article className={classes.back}>
          <p onClick={() => navigate(-1)}>Terug</p>
        </article>
        <img src={foto} alt="notAvailable" />
        <article className={classes.one}>
          <h4>{vehicle.brandModel}</h4>
          <p>Kenteken: {vehicle.licensePlate}</p>
          <p>Chassisnummer: {vehicle.vinNumber}</p>
          {/* <p> {vehicle.fuel}</p> */}
          <p>Kleur: {vehicle.color}</p>
          <p>Aantal deuren: {vehicle.doors}</p>
        </article>

        <article className={classes.two}>
          <p onClick={() => navigate(`/vehicles/${vehicle.vinNumber}/edit`)}>
            Bewerken
          </p>
          <p onClick={() => setDeletePopup(true)}>Verwijderen</p>
        </article>

        {/* <article className={classes.three}>
          <h3>Alle Voertuigen</h3>

          <ul>
            <li></li>
          </ul>
        </article> */}
      </article>

      <DeletePopup trigger={deletePopup} setTrigger={setDeletePopup}>
        <p>Zeker dat u deze voertuig wilt verwijderen?</p>
      </DeletePopup>
    </>
  );
};

export default VehicleItem;
