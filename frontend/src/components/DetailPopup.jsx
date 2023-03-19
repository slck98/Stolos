import React from "react";
import classes from "../css/DetailPopup.module.css";

const DetailPopUp = (props) => {
  return props.trigger ? (
    <div className={classes.popup}>
      <div className={classes.popupInner}>
        {props.children}
        <button className="close-btn" onClick={() => props.setTrigger(false)}>
          Sluiten
        </button>
      </div>
    </div>
  ) : (
    ""
  ); // If trigger is false, return empty string
};

export default DetailPopUp;
