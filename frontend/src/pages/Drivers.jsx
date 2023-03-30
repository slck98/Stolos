import React, { Suspense } from "react";
import { useLoaderData, json, defer, Await } from "react-router-dom";
import DriverList from "../components/Lists";

const DriversPage = () => {
  const { drivers } = useLoaderData();

  return (
    <Suspense fallback={<p>Laden...</p>}>
      <Await resolve={drivers}>
        {(loadedDrivers) => <DriverList drivers={loadedDrivers} />}
      </Await>
    </Suspense>
  );
};

export default DriversPage;

const loadDrivers = async () => {
  const response = await fetch("https://localhost:7144/driver");
  if (!response.ok) {
    return json({ message: "Chauffeurs ophalen mislukt." }, { status: 500 });
  } else {
    const res = await response.json();
    return res;
  }
};

export function loader() {
  return defer({
    drivers: loadDrivers(),
  });
}
