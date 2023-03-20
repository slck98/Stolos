import React from "react";
import classes from "../css/DetailPopup.module.css";

const UpdatePopup = (props) => {
  return props.trigger ? (
    <div className={classes.popup}>
      <div className={classes.popupInner}>
        {props.children}
        <div className="btnAddPage">
          <button className="close-btn" onClick={() => props.setTrigger(false)}>
            Sluiten
          </button>
          <button className="save-btn" onClick={() => props.setTrigger(false)}>
            Opslaan
          </button>
        </div>
      </div>
    </div>
  ) : (
    ""
  );
};

export default UpdatePopup;
