import React, { useState } from 'react';
import foto from '../images/user.png';
import classes from '../css/Edit.module.css';
import EditCard from './EditCard';
import { Licenses } from './DataLicenses';
import {
  Form,
  json,
  redirect,
  useActionData,
  useNavigate,
  useNavigation,
} from 'react-router-dom';
import Multiselect from 'multiselect-react-dropdown';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBan, faFloppyDisk } from '@fortawesome/free-solid-svg-icons';

const DriverForm = ({ method, driver }) => {
  const [input, setInput] = useState();
  const data = useActionData();
  const navigate = useNavigate();
  const navigation = useNavigation();

  const isSubmitting = navigation.state === 'submitting';

  function cancelHandler() {
    navigate('..');
  }

  let listLicense;
  if (driver) {
    listLicense = [...driver.licenses];
  }

  const handleOnRemove = option => {
    listLicense = option;
  };

  const handeOnSelect = option => {
    listLicense = [...option];
  };

  const changeHandler = e => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };

  return (
    <EditCard>
      <Form method={method} className={classes.table}>
        {data && data.errors && (
          <ul>
            {Object.values(data.errors).map(err => (
              <li key={err}>{err}</li>
            ))}
          </ul>
        )}
        <img src={foto} alt="notAvailable" />
        <div className={classes.data}>
          <label htmlFor="firstname">Voornaam:</label>
          <input
            id="firstname"
            type="text"
            name="firstName"
            required
            defaultValue={driver ? driver.firstName : ''}
            onChange={changeHandler}
          />
          <label htmlFor="lastname">Familienaam:</label>
          <input
            id="lastname"
            type="text"
            name="lastName"
            required
            defaultValue={driver ? driver.lastName : ''}
            onChange={changeHandler}
          />
          <label htmlFor="birthdate">Geboortedatum:</label>
          <input
            id="birthdate"
            type="date"
            name="birthDate"
            required
            defaultValue={driver ? driver.birthDate.split('T')[0] : ''}
            onChange={changeHandler}
          />
          <label htmlFor="natregnumber">Rijksregisternummer:</label>
          <input
            id="natregnumber"
            type="text"
            name="natregnumber"
            defaultValue={driver ? driver.natRegNum : ''}
            onChange={changeHandler}
          />
          <label htmlFor="address">Adres:</label>
          <input
            id="address"
            type="text"
            name="address"
            defaultValue={driver ? driver.address : ''}
            onChange={changeHandler}
          />
          <label htmlFor="licenses">Rijbewijzen: </label>
          <Multiselect
            className={classes.multi}
            id="licences"
            isObject={false}
            options={Licenses}
            selectedValues={driver ? driver.licenses : ''}
            onRemove={handleOnRemove}
            onSelect={handeOnSelect}
          />
          <label htmlFor="address">Voertuig:</label>
          <select
            id="vehicle"
            name="vehicle"
            defaultValue={driver ? driver.gascardNum : ''}
            onChange={changeHandler}
          ></select>
        </div>
        <div className={classes.buttons}>
          <p></p>
          <button disabled={isSubmitting} className={classes.save}>
            <FontAwesomeIcon icon={faFloppyDisk} /> Opslaan
          </button>
          <button onClick={cancelHandler} className={classes.cancel}>
            <FontAwesomeIcon icon={faBan} /> Annuleren
          </button>
        </div>
      </Form>
    </EditCard>
  );
};

export default DriverForm;

export async function action({ request, params }) {
  const method = request.method;
  const data = await request.formData();
  const driverData = {
    firstName: data.get('firstName'),
    lastName: data.get('lastName'),
    birthDate: data.get('birthDate'),
    natRegNum: data.get('natregnumber'),
    address: data.get('address'),
    license: data.get('licenses'),
  };

  let url = process.env.REACT_APP_DRIVER_URL;

  if (method === 'PUT') {
    const { driverID } = params;
    driverData.driverID = driverID;
  }

  const response = await fetch(url, {
    method: method,
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(driverData),
  });

  if (response.status === 422) {
    return response;
  }

  if (!response.ok) {
    throw json({ message: 'Kon de bestuurder niet opslaan' }, { status: 500 });
  }

  return redirect('/drivers');
}
