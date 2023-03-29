import React, { Suspense } from "react";
import {
  useRouteLoaderData,
  json,
  defer,
  redirect,
  Await,
} from "react-router-dom";
import GascardItem from "../components/GascardItem";
import GascardList from "../components/GascardList";

const GascardDetail = () => {
  const { gascard, gascards } = useRouteLoaderData("gascard-detail");
  return (
    <>
      <Suspense>
        <Await resolve={gascard}>
          {(loadedGascard) => <GascardItem gascard={loadedGascard} />}
        </Await>
      </Suspense>
      <Suspense>
        <Await resolve={gascards}>
          {(loadedGascards) => <GascardList gascards={loadedGascards} />}
        </Await>
      </Suspense>
    </>
  );
};

export default GascardDetail;

async function loadGascard(gasCardID) {
  const response = await fetch(
    "https://localhost:7144/gascard/" + gasCardID.toString()
  );
  if (!response.ok) {
    throw json(
      { message: "Kon de details van de tankkaart niet ophalen" },
      { status: 500 }
    );
  } else {
    const resData = await response.json();
    return resData;
  }
}

async function loadGascards() {
  const response = await fetch("https://localhost:7144/gascard");

  if (!response.ok) {
    return json({ message: "Tankkaarten ophalen mislukt." }, { status: 500 });
  } else {
    const resData = await response.json();
    return resData.gascards;
  }
}

export async function loader({ req, params }) {
  const { gasCardID } = params;
  return defer({
    gascard: await loadGascard(gasCardID.toString()),
    gascards: loadGascards(),
  });
}

export async function action({ params, request }) {
  const response = await fetch(
    "https://localhost:7144/gascard/" + params.gasCardID.toString(),
    {
      method: request.method,
    }
  );
  if (!response.ok) {
    throw json({ message: "Error" }, { status: 500 });
  }
  return redirect("/gascards");
}
