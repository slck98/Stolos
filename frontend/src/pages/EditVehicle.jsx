import React, { Suspense } from "react";
import {
  Await,
  useRouteLoaderData,
  json,
  redirect,
  defer,
} from "react-router-dom";
import VehicleEdit from "../components/VehicleEdit";

const EditVehiclePage = () => {
  const { vehicle } = useRouteLoaderData("vehicle-detail");
  return (
    <Suspense>
      <Await resolve={vehicle}>
        {(loadVehicle) => <VehicleEdit vehicle={loadVehicle} />}
      </Await>
    </Suspense>
  );
};

export default EditVehiclePage;

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

export async function loader({ req, params }) {
  const { vinNumber } = params;
  return defer({
    vehicle: await loadVehicle(vinNumber),
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
