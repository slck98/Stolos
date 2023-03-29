import React, { useState } from "react";

const DriverEdit = ({ driver }) => {
  const [input, setInput] = useState();

  return <article>{driver.firstName}</article>;
};

export default DriverEdit;
