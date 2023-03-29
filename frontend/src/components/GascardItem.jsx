import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import classes from "../css/GascardItem.module.css";
import DeletePopup from "./DeletePopup";

const GascardItem = ({ gascard }) => {
  const [deletePopup, setDeletePopup] = useState(false);

  const navigate = useNavigate();
  return (
    <>
      <article className={classes.container}>
        <article className={classes.back}>
          <p onClick={() => navigate(-1)}>Terug</p>
        </article>
        <article className={classes.one}>
          <h4>{gascard.cardNumber}</h4>
          <p>Vervaldatum: {gascard.expiringDate}</p>
          if(gascard.pinCode !== null) {<p>Pin: {gascard.pinCode}</p>} else
          {<p>Pin: N.V.T.</p>}
          {/* <p>Brandstoftypen: {gascard.fuelTypes}</p> */}
          if(gascard.blocked === true) {<p>Geblokkeerd: Ja</p>} else
          {<p>Geblokkeerd: Nee</p>}
          if(gascard.driver !== null) {<p>Bestuurder: {gascard.driver}</p>} else
          {<p>Bestuurder: N.V.T.</p>}
        </article>
      </article>

      <DeletePopup trigger={deletePopup} setTrigger={setDeletePopup}>
        <p>Zeker dat u deze voertuig wilt verwijderen?</p>
      </DeletePopup>
    </>
  );
};

export default GascardItem;
