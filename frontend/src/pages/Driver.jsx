import React, { useState, useEffect } from "react";
import axios from "axios";
import classes from "../css/Driver.module.css";
import logo from "../images/logoLong.png";
import PopupDetail from "../components/DetailPopup";
import { RiDeleteBin5Line } from "react-icons/ri";
import { BsFillPencilFill } from "react-icons/bs";
import { TiArrowRightThick } from "react-icons/ti";

const DriverPage = () => {
  const [drivers, setDrivers] = useState([]);
  const [iconPopup, setIconPopup] = useState(false);

  const fetchData = () => {
    axios.get("https://swapi.dev/api/people").then((response) => {
      setDrivers(response.data.results);
    });
  };

  useEffect(() => {
    fetchData();
  }, []);
  return (
    <div className={classes.container}>
      <div className={classes.headerDriver}>
        <h1>Bestuurders</h1>
        <img src={logo} alt="logo"></img>
      </div>

      <hr className={classes.line} />

      <div className={classes.one}>
        <input type="text" id="searchTxtbox" name="searchTxtBox"></input>
        <button type="button">Zoek</button>
        <button type="button">Toevoegen</button>
      </div>

      <div className={classes.two}>
        <>
          {drivers &&
            drivers.length > 0 &&
            drivers.map((drivers) => (
              <li key={drivers.id}>
                <p>{drivers.name} </p>
                <p className={classes.icons}>
                  <RiDeleteBin5Line size={"30px"} />
                  <BsFillPencilFill
                    size={"30px"}
                    onClick={() => {
                      alert("clicked");
                    }}
                  />
                  <TiArrowRightThick
                    size={"30px"}
                    onClick={() => setIconPopup(true)}
                  />
                </p>
              </li>
            ))}
        </>
      </div>
      <PopupDetail trigger={iconPopup} setTrigger={setIconPopup} >
        <p>Name: </p>
        <p>Height: </p>
        <p>Mass: </p>
        <p>Hair color:</p>
      </PopupDetail>
    </div>
  );
};

export default DriverPage;
