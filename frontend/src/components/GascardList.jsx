import React from "react";
import { Link } from "react-router-dom";
import classes from "../css/GascardList.module.css";
import logo from "../images/logoLong.png";

const GascardList = ({ gascards }) => {
  return (
    <article className={classes.containter}>
      <article className={classes.headerPage}>
        <h1>Brandstofkaarten</h1>
        <img src={logo} alt="logo" />
      </article>

      <hr className={classes.line} />
      <ul>
        {gascards.map((gascard) => (
          <li key={gascard.cardNumber}>
            <Link to={gascard.cardNumber}>{gascard.cardNumber}</Link>
          </li>
        ))}
      </ul>
    </article>
  );
};

export default GascardList;
