import React, { Suspense } from 'react';
import {
  useRouteLoaderData,
  json,
  defer,
  Await,
  redirect,
} from 'react-router-dom';
import DriverEdit from '../components/DriverEdit';

const EditDriverPage = () => {
  const { driver } = useRouteLoaderData('driver-detail');
  return (
    <Suspense>
      <Await resolve={driver}>
        {loadDriver => <DriverEdit driver={loadDriver} />}
      </Await>
    </Suspense>
  );
};

export default EditDriverPage;

async function loadDriver(driverID) {
  const response = await fetch(
    'https://localhost:7144/driver/' + driverID.toString()
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

export async function loader({ req, params }) {
  const { driverID } = params;
  return defer({
    driver: await loadDriver(driverID.toString()),
  });
}

export async function action({ params, request }) {
  const response = await fetch(
    'https://localhost:7144/driver/' + params.driverID.toString(),
    {
      method: request.method,
    }
  );
  if (!response.ok) {
    throw json({ message: 'Error.' }, { status: 500 });
  }
  return redirect('/drivers');
}
