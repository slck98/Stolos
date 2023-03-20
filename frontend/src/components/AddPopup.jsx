import React from "react";
import classes from "../css/DetailPopup.module.css";

const AddPopup = (props) => {
  return props.trigger ? (
    <div className={classes.popup}>
      <div className={classes.popupInner}>
        {props.children}
        <div className="btnAddPage">
          <button className="close-btn" onClick={() => props.setTrigger(false)}>
            Sluiten
          </button>
          <button className="add-btn" onClick={() => props.setTrigger(false)}>
            Toevoegen
          </button>
        </div>
      </div>
    </div>
  ) : (
    ""
  );
};

export default AddPopup;
