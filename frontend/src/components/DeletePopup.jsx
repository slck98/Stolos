import React from "react";
import classes from "../css/DeletePopup.module.css";

const DeletePopup = (props) => {
  const navigateTo = () => {
    props.history.push("/vehicles");
  };

  return props.trigger ? (
    <div className={classes.popup}>
      <div className={classes.popupInner}>
        {props.children}
        <div className="btnAddPage">
          <button onClick={() => props.setTrigger(false)}>Sluiten</button>
          <button onClick={() => props.setTrigger(false) && navigateTo}>
            Verwijderen
          </button>
        </div>
      </div>
    </div>
  ) : (
    ""
  );
};

export default DeletePopup;
