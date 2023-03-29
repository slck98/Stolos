import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import foto from "../images/notAvailable.png";
import classes from "../css/GascardEdit.module.css";

const GascardEdit = () => {
  const [input, setInput] = useState();
  const navigate = useNavigate();

  const changeHandler = (e) => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };

  return (
    <article className={classes.container}>
      <img src={foto} alt="notAvailable" />
      <article className={classes.one}></article>
    </article>
  );
};

export default GascardEdit;
