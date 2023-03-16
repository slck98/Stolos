import React, { useState, useEffect } from "react";
import axios from "axios";
import "../css/Driver.css";
import logo from "../images/logoLong.png";
import { RiDeleteBin5Line } from "react-icons/ri";
import { BsFillPencilFill } from "react-icons/bs";
import { TiArrowRightThick } from "react-icons/ti";

const DriverPage = () => {
  const [drivers, setDrivers] = useState([]);

  const fetchData = () => {
    axios.get("https://swapi.dev/api/people").then((response) => {
      setDrivers(response.data.results);
    });
  };

  useEffect(() => {
    fetchData();
  }, []);
  return (
    <div className="container">
      <div className="headerDriver">
        <h1>Bestuurders</h1>
        <img src={logo} alt="logo"></img>
      </div>

      <hr className="line" />

      <div className="one">
        <input type="text" id="searchTxtbox" name="searchTxtBox"></input>
        <button type="button">Zoek</button>
        <button type="button">Toevoegen</button>
      </div>

      <div className="two">
        <>
          {drivers &&
            drivers.length > 0 &&
            drivers.map((drivers) => (
              <li key={drivers.id}>
                <p>{drivers.name} </p>
                <p className="icons">
                  <RiDeleteBin5Line />
                  <BsFillPencilFill />
                  <TiArrowRightThick />
                </p>
              </li>
            ))}
        </>
      </div>
    </div>
  );
};

export default DriverPage;
