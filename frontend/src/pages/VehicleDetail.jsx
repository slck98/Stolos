import React, { Suspense } from "react";
import {
  useRouteLoaderData,
  json,
  defer,
  redirect,
  Await,
} from "react-router-dom";
import VehicleItem from "../components/VehicleItem";
import VehicleList from "../components/VehicleList";

const VehicleDetailPage = () => {
  const { vehicles, vehicle } = useRouteLoaderData("vehicle-detail");
  return (
    <>
      <Suspense>
        <Await resolve={vehicle}>
          {(loadedVehicle) => <VehicleItem vehicle={loadedVehicle} />}
        </Await>
      </Suspense>
      <Suspense>
        <Await resolve={vehicles}>
          {(loadedVehicles) => <VehicleList vehicles={loadedVehicles} />}
        </Await>
      </Suspense>
    </>
  );
};

export default VehicleDetailPage;

async function loadVehicle(vinNumber) {
  const response = await fetch("https://localhost:7144/vehicle/" + vinNumber);
  if (!response.ok) {
    throw json(
      { message: "Kon de details van het voertuig niet ophalen" },
      { status: 500 }
    );
  } else {
    const resData = await response.json();
    return resData;
  }
}

async function loadVehicles() {
  const response = await fetch("https://localhost:7144/vehicle");

  if (!response.ok) {
    return json({ message: "Voertuigen ophalen mislukt." }, { status: 500 });
  } else {
    const resData = await response.json();
    return resData.vehicles;
  }
}

export async function loader({ req, params }) {
  const { vinNumber } = params;
  return defer({
    vehicle: await loadVehicle(vinNumber),
    vehicles: loadVehicles(),
  });
}

export async function action({ params, request }) {
  const response = await fetch(
    "https://localhost:7144/vehicle/" + params.vinNumber,
    {
      method: request.method,
    }
  );
  if (!response.ok) {
    throw json({ message: "Error." }, { status: 500 });
  }
  return redirect("/vehicles");
}
