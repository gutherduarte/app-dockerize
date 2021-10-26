import "./styles.css";
import React, { useState,useEffect } from "react";
import { fetchProducto } from "./ServicesProducto";

import Menu from "./menu";
function App() {
  const [data, setData] = useState([]);
  useEffect(() => {
    fetchProducto.GetProducto().then((response) => setData(response));
  }, []);

  return (
    <div className="Container">
      <Menu data={data} tittle="Hola mundos" />
    </div>
  );
}

export default App;
