import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import classes from "../css/VehicleItem.module.css";
import foto from "../images/notAvailable.png";
import DeletePopup from "./DeletePopup";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faPen,
  faTrashCan,
  faCircleArrowLeft,
} from "@fortawesome/free-solid-svg-icons";

const VehicleItem = ({ vehicle }) => {
  const [deletePopup, setDeletePopup] = useState(false);

  const navigate = useNavigate();

  return (
    <>
      <header className={classes.container}>
        <article className={classes.back}>
          <p onClick={() => navigate(-1)}>Terug</p>
          {/* <FontAwesomeIcon icon={faCircleArrowLeft} /> Moet er nog worden tussen geplaatst*/}
        </article>
        <img src={foto} alt="notAvailable" />
        <table className={classes.one}>
          <tr>
            <th colSpan="2">{vehicle.brandModel}</th>
          </tr>
          <tr>
            <td>Kenteken: </td>
            <td> {vehicle.licensePlate}</td>
          </tr>
          <tr>
            <td>Chassisnummer: </td>
            <td> {vehicle.vin}</td>
          </tr>
          <tr>
            <td>Type: </td>
            <td>{vehicle.vehicleType}</td>
          </tr>
          <tr>
            <td>Brandstof: </td>
            <td> {vehicle.fuelType}</td>
          </tr>
          <tr>
            <td>Kleur: </td>
            <td> {vehicle.color}</td>
          </tr>
          <tr>
            <td>Aantal deuren: </td>
            <td> {vehicle.doors.toString()}</td>
          </tr>
          <tr>
            <td> Bestuurder: </td>
            <td>
              {" "}
              {vehicle.driver.firstName} {vehicle.driver.lastName}
            </td>
          </tr>
        </table>

        <article className={classes.button}>
          <p
            onClick={() => navigate(`/vehicles/${vehicle.vin}/edit`)}
            className={classes.bewerken}
          >
            <FontAwesomeIcon icon={faPen} /> Bewerken
          </p>
          <p
            onClick={() => setDeletePopup(true)}
            className={classes.verwijderen}
          >
            <FontAwesomeIcon icon={faTrashCan} /> Verwijderen
          </p>
        </article>
      </header>

      <DeletePopup trigger={deletePopup} setTrigger={setDeletePopup}>
        <p>Zeker dat u deze voertuig wilt verwijderen?</p>
      </DeletePopup>
    </>
  );
};

export default VehicleItem;
