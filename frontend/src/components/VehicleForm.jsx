import React, { useState } from 'react';
import foto from '../images/notAvailable.png';
import EditCard from './EditCard';
import {
  Form,
  json,
  redirect,
  useActionData,
  useNavigate,
  useNavigation,
} from 'react-router-dom';

import classes from '../css/Edit.module.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBan, faFloppyDisk } from '@fortawesome/free-solid-svg-icons';

const VehicleForm = ({ method, vehicle }) => {
  const data = useActionData();
  const navigate = useNavigate();
  const navigation = useNavigation();

  const isSubmitting = navigation.state === 'submitting';

  function cancelHandler() {
    navigate('..');
  }
  const [input, setInput] = useState();

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
          <label htmlFor="brandmodel">Model:</label>
          <input
            id="brandmodel"
            type="text"
            name="brandmodel"
            required
            defaultValue={vehicle ? vehicle.brandModel : ''}
            onChange={changeHandler}
          />
          <label htmlFor="licenseplate">Kenteken:</label>
          <input
            id="licenseplate"
            type="text"
            name="licenseplate"
            required
            defaultValue={vehicle ? vehicle.licensePlate : ''}
            onChange={changeHandler}
          />
          <label htmlFor="vin">Chassisnummer:</label>
          <input
            id="vin"
            type="text"
            name="vin"
            required
            defaultValue={vehicle ? vehicle.vin : ''}
            onChange={changeHandler}
          />
          <label htmlFor="vehicletype">Type:</label>
          <input
            id="vehicletype"
            type="text"
            name="vehicletype"
            required
            defaultValue={vehicle ? vehicle.vehicleType : ''}
            onChange={changeHandler}
          />
          <label htmlFor="fueltype">Brandstof:</label>
          <input
            id="fueltype"
            type="text"
            name="fueltype"
            required
            defaultValue={vehicle ? vehicle.fuelType : ''}
            onChange={changeHandler}
          />
          <label htmlFor="color">Kleur:</label>
          <input
            id="color"
            type="text"
            name="color"
            defaultValue={vehicle ? vehicle.color : ''}
            onChange={changeHandler}
          />
          <label htmlFor="doors">Aantal deuren:</label>
          <input
            id="doors"
            type="text"
            name="doors"
            defaultValue={vehicle ? vehicle.doors : ''}
            onChange={changeHandler}
          />
        </div>
        <div className={classes.buttons}>
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

export default VehicleForm;

export async function action({ request, params }) {
  const method = request.method;
  const data = await request.formData();
  const vehicleData = {
    brandModel: data.get('brandmodel'),
    licensePlate: data.get('licenseplate'),
    vin: data.get('vin'),
    type: data.get('type'),
    fuelType: data.get('fueltype'),
    color: data.get('color'),
    doors: data.get('doors'),
  };

  let url = 'https://localhost:7144/vehicle';

  if (method === 'PUT') {
    const { vin } = params;
    url = `${url}/${vin}`;
  }

  const response = await fetch(url, {
    method: method,
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(vehicleData),
  });

  if (response.status === 422 || response.ok) {
    return response;
  }

  if (!response.ok) {
    throw json({ message: 'Kon het voertuig niet opslaan' }, { status: 500 });
  }

  return redirect('/vehicles');
}