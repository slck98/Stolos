import React, { useState } from "react";
import foto from "../images/notAvailable.png";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBan, faFloppyDisk } from "@fortawesome/free-solid-svg-icons";
import classes from "../css/Edit.module.css";

import EditCard from "./EditCard";
import {
  Form,
  json,
  redirect,
  useActionData,
  useNavigate,
  useNavigation,
} from "react-router-dom";

const GascardForm = ({ method, gascard }) => {
  const data = useActionData();
  const navigate = useNavigate();
  const navigation = useNavigation();

  const isSubmitting = navigation.state === "submitting";

  function cancelHandler() {
    navigate("..");
  }
  const [input, setInput] = useState();

  const changeHandler = (e) => {
    setInput({ ...input, [e.target.name]: e.target.value });
  };

  return (
    <EditCard>
      <Form method={method} className={classes.table}>
        {data && data.errors && (
          <ul>
            {Object.values(data.errors).map((err) => (
              <li key={err}>{err}</li>
            ))}
          </ul>
        )}
        <img src={foto} alt="notAvailable" />
        <div className={classes.data}>
          <label htmlFor="cardnumber">Kaartnummer:</label>
          <input
            id="cardnumber"
            type="text"
            name="cardnumber"
            defaultValue={gascard ? gascard.cardNumber : ""}
            readOnly
            required
          />
          <label htmlFor="pincode">Pincode:</label>
          <input
            id="pincode"
            type="text"
            name="pincode"
            defaultValue={gascard ? gascard.pincode : ""}
            onChange={changeHandler}
          />
          <label htmlFor="fueltypes">Brandstoftypes:</label>
          <input
            id="fueltypes"
            type="text"
            name="fueltypes"
            required
            defaultValue={gascard ? gascard.fuelTypes : ""}
            onChange={changeHandler}
          />
          <label htmlFor="blocked">Geblokkeerd:</label>
          <select id="blocked">
            <option value="false">Nee</option>
            <option value="true">Ja</option>
          </select>
        </div>
        <div className={classes.buttons}>
          <button disabled={isSubmitting} className={classes.save}>
            <FontAwesomeIcon icon={faFloppyDisk} /> Opslaan
          </button>
          <button onClick={cancelHandler} className={classes.cancel}>
            <FontAwesomeIcon icon={faBan} /> Annuleren
          </button>
        </div>
      </Form>
    </EditCard>
  );
};

export default GascardForm;

export async function action({ request, params }) {
  const method = request.method;
  const data = await request.formData();
  const gascardData = {
    cardNumber: data.get("cardnumber"),
    pincode: data.get("pincode"),
    fuelTypes: data.get("fueltypes"),
    blocked: data.get("blocked"),
  };

  let url = "https://localhost:7144/gascard";

  if (method === "PUT") {
    const { cardNumber } = params;
    url = `${url}/${cardNumber}`;
  }

  const response = await fetch(url, {
    method: method,
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(gascardData),
  });

  if (response.status === 422 || response.ok) {
    return response;
  }

  if (!response.ok) {
    throw json({ message: "Kon de tankkaart niet opslaan" }, { status: 500 });
  }

  return redirect("/gascards");
}
