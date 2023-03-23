import React, { useState, useEffect } from 'react';
import axios from 'axios';
import classes from '../css/Driver.module.css';
import logo from '../images/logoLong.png';
import DetailPopup from '../components/DetailPopup';
import AddPopup from '../components/AddPopup';
import UpdatePopup from '../components/UpdatePopup';
import DeletePopup from '../components/DeletePopup';
import { RiDeleteBin5Line } from 'react-icons/ri';
import { BsFillPencilFill } from 'react-icons/bs';
import { TiArrowRightThick } from 'react-icons/ti';

const DriverPage = () => {
  const [drivers, setDrivers] = useState([]);
  const [detailPopup, setDetailPopup] = useState(false);
  const [addPopup, setAddPopup] = useState(false);
  const [updatePopup, setUpdatePopup] = useState(false);
  const [deletePopup, setDeletePopup] = useState(false);

  const fetchData = () => {
    axios.get('https://swapi.dev/api/people').then(response => {
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
        <input
          type="text"
          className="searchTxtbox"
          placeholder="Zoeken..."
        ></input>
        <button type="button">Zoek</button>
        <button type="button" onClick={() => setAddPopup(true)}>
          Toevoegen
        </button>
      </div>

      <div className={classes.two}>
        <>
          {drivers &&
            drivers.length > 0 &&
            drivers.map(drivers => (
              <li key={drivers.name}>
                <p>{drivers.name} </p>
                <p className={classes.icons}>
                  <RiDeleteBin5Line
                    size={'30px'}
                    onClick={() => setDeletePopup(true)}
                  />
                  <BsFillPencilFill
                    size={'30px'}
                    onClick={() => setUpdatePopup(true)}
                  />
                  <TiArrowRightThick
                    size={'30px'}
                    onClick={() => setDetailPopup(true)}
                  />
                </p>
              </li>
            ))}
        </>
      </div>
      <DetailPopup trigger={detailPopup} setTrigger={setDetailPopup}>
        <p>Naam: </p>
        <p>Voornaam: </p>
        <p>Adres: </p>
        <p>Geboortedatum:</p>
        <p>Rijkregisternummer:</p>
        <p>Type rijbewijs:</p>
        <p>Voertuig:</p>
        <p>Tankkaart:</p>
      </DetailPopup>

      <AddPopup trigger={addPopup} setTrigger={setAddPopup}>
        <div className={classes.addPopup}>
          <span>
            <p>Naam: </p>
            <input type="text" id="name" name="name" />
          </span>
          <span>
            <p>Voornaam:</p>{' '}
            <input type="text" id="firstname" name="firstname" />
          </span>
          <span>
            <p>Adres:</p>
            <input type="text" id="address" name="address" />
          </span>
          <span>
            <p>Geboortedatum:</p>
            <input type="date" id="birthdate" name="birthdate" />
          </span>
          <span>
            <p>Rijkregisternummer:</p>
            <input type="text" id="rrn" name="rrn" />
          </span>
          <span>
            <p>Type rijbewijs:</p>
            <input type="text" id="drivinglicense" name="drivinglicense" />
          </span>
          <span>
            <p>Voertuig:</p>
            <input type="text" id="vehicle" name="vehicle" />
          </span>
          <span>
            <p>Tankkaart:</p>
            <input type="text" id="gascard" name="gascard" />
          </span>
        </div>
      </AddPopup>

      <UpdatePopup trigger={updatePopup} setTrigger={setUpdatePopup}>
        <div className={classes.addPopup}>
          <span>
            <p>Naam: </p>
            <input type="text" id="name" name="name" />
          </span>
          <span>
            <p>Voornaam:</p>{' '}
            <input type="text" id="firstname" name="firstname" />
          </span>
          <span>
            <p>Adres:</p>
            <input type="text" id="address" name="address" />
          </span>
          <span>
            <p>Geboortedatum:</p>
            <input type="date" id="birthdate" name="birthdate" />
          </span>
          <span>
            <p>Rijkregisternummer:</p>
            <input type="text" id="rrn" name="rrn" />
          </span>
          <span>
            <p>Type rijbewijs:</p>
            <input type="text" id="drivinglicense" name="drivinglicense" />
          </span>
          <span>
            <p>Voertuig:</p>
            <input type="text" id="vehicle" name="vehicle" />
          </span>
          <span>
            <p>Tankkaart:</p>
            <input type="text" id="gascard" name="gascard" />
          </span>
        </div>
      </UpdatePopup>

      <DeletePopup trigger={deletePopup} setTrigger={setDeletePopup}>
        <p>Naam: </p>
        <p>Voornaam: </p>
        <p>Adres: </p>
        <p>Geboortedatum:</p>
        <p>Rijkregisternummer:</p>
        <p>Type rijbewijs:</p>
        <p>Voertuig:</p>
        <p>Tankkaart:</p>
      </DeletePopup>
    </div>
  );
};

export default DriverPage;
