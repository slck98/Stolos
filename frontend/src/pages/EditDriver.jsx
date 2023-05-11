import React, { Suspense } from 'react';
import {
  useRouteLoaderData,
  json,
  defer,
  Await,
  redirect,
} from 'react-router-dom';
import DriverForm from '../components/DriverForm';

const EditDriverPage = () => {
  const { driver, vehicles } = useRouteLoaderData('driver-detail');
  return (
    <Suspense>
      <Await resolve={[driver, vehicles]}>
        {loadDriver => (
          <DriverForm
            driver={loadDriver[0]}
            vehicles={loadDriver[1]}
            method="put"
          />
        )}
      </Await>
    </Suspense>
  );
};

export default EditDriverPage;

async function loadDriver(driverID) {
  const response = await fetch(
    process.env.REACT_APP_DRIVER_URL + driverID.toString()
  );
  if (!response.ok) {
    throw json(
      { message: 'Kon de details van de chauffeur niet ophalen' },
      { status: 500 }
    );
  } else {
    const resData = await response.json();
    return resData;
  }
}

async function loadVehicles() {
  const response = await fetch(process.env.REACT_APP_VEHICLE_URL);

  if (!response.ok) {
    return json({ message: 'Voertuigen ophalen mislukt.' }, { status: 500 });
  } else {
    const resData = await response.json();
    return resData.vehicles;
  }
}

export async function loader({ req, params }) {
  const { driverID } = params;
  return defer({
    driver: await loadDriver(driverID.toString()),
    vehicles: loadVehicles(),
  });
}

export async function action({ params, request }) {
  const response = await fetch(
    process.env.REACT_APP_DRIVER_URL + params.driverID.toString(),
    {
      method: request.method,
    }
  );
  if (!response.ok) {
    throw json({ message: 'Error.' }, { status: 500 });
  }
  return redirect('/drivers');
}
