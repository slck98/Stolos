import React, { Suspense } from "react";
import { Await, useLoaderData, json, defer } from "react-router-dom";
import GascardList from "../components/GascardList";

const GascardPage = () => {
  const { gascards } = useLoaderData();

  return (
    <Suspense fallback={<p>Laden...</p>}>
      <Await resolve={gascards}>
        {(loadedGascards) => <GascardList gascards={loadedGascards} />}
      </Await>
    </Suspense>
  );
};

export default GascardPage;

const loadGascards = async () => {
  const response = await fetch("https://localhost:7144/gascard");
  if (!response.ok) {
    return json(
      { message: "Brandstofkaarten ophalen mislukt." },
      { status: 500 }
    );
  } else {
    const res = await response.json();
    return res;
  }
};

export function loader() {
  return defer({
    gascards: loadGascards(),
  });
}
