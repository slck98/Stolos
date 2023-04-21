import React, { Suspense } from 'react';
import {
  Await,
  useRouteLoaderData,
  json,
  redirect,
  defer,
} from 'react-router-dom';
import VehicleForm from '../components/VehicleForm';

const EditVehiclePage = () => {
  const { vehicle } = useRouteLoaderData('vehicle-detail');
  return (
    <Suspense>
      <Await resolve={vehicle}>
        {loadVehicle => <VehicleForm vehicle={loadVehicle} method="put" />}
      </Await>
    </Suspense>
  );
};

export default EditVehiclePage;

async function loadVehicle(vin) {
  const response = await fetch('https://localhost:7144/vehicle/' + vin);
  if (!response.ok) {
    throw json(
      { message: 'Kon de details van het voertuig niet ophalen' },
      { status: 500 }
    );
  } else {
    const resData = await response.json();
    return resData;
  }
}

export async function loader({ req, params }) {
  const { vin } = params;
  return defer({
    vehicle: await loadVehicle(vin),
  });
}

export async function action({ params, request }) {
  const response = await fetch('https://localhost:7144/vehicle/' + params.vin, {
    method: request.method,
  });
  if (!response.ok) {
    throw json({ message: 'Error.' }, { status: 500 });
  }
  return redirect('/vehicles');
}
