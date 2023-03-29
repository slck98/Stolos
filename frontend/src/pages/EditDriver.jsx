import React, { Suspense } from "react";
import {
  useRouteLoaderData,
  json,
  defer,
  Await,
  redirect,
} from "react-router-dom";
import DriverEdit from "../components/DriverEdit";

const EditDriverPage = () => {
  const { driver } = useRouteLoaderData("driver-detail");
  return (
    <Suspense>
      <Await resolve={driver}>
        {(loadDriver) => <DriverEdit driver={loadDriver} />}
      </Await>
    </Suspense>
  );
};

export default EditDriverPage;

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

export async function loader({ req, params }) {
  const { natRegNum } = params;
  return defer({
    driver: await loadDriver(natRegNum),
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
    throw json({ message: "Error." }, { status: 500 });
  }
  return redirect("/drivers");
}
