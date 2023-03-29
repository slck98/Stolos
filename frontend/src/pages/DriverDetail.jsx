import React, { Suspense } from "react";
import {
  useRouteLoaderData,
  json,
  defer,
  Await,
  redirect,
} from "react-router-dom";
import DriverItem from "../components/DriverItem";
import DriverList from "../components/DriverList";

const DriverDetailPage = () => {
  const { drivers, driver } = useRouteLoaderData("driver-detail");
  return (
    <>
      <Suspense>
        <Await resolve={driver}>
          {(loadedDriver) => <DriverItem driver={loadedDriver} />}
        </Await>
      </Suspense>
      <Suspense>
        <Await resolve={drivers}>
          {(loadedDrivers) => <DriverList drivers={loadedDrivers} />}
        </Await>
      </Suspense>
    </>
  );
};

export default DriverDetailPage;

async function loadDriver(natRegNum) {
  const response = await fetch("https://localhost:7144/driver/" + natRegNum);
  if (!response.ok) {
    throw json(
      { message: "Kon de details van de chauffeur niet ophalen" },
      { status: 500 }
    );
  } else {
    const resData = await response.json();
    return resData;
  }
}

async function loadDrivers() {
  const response = await fetch("https://localhost:7144/driver");

  if (!response.ok) {
    return json({ message: "Chauffeurs ophalen mislukt." }, { status: 500 });
  } else {
    const resData = await response.json();
    return resData.drivers;
  }
}

export async function loader({ req, params }) {
  const { natRegNum } = params;
  return defer({
    driver: await loadDriver(natRegNum),
    drivers: loadDrivers(),
  });
}

export async function action({ params, request }) {
  const response = await fetch(
    "https://localhost:7144/driver/" + params.natRegNum,
    {
      method: request.method,
    }
  );
  if (!response.ok) {
    throw json({ message: "Error" }, { status: 500 });
  }
  return redirect("/driver");
}
