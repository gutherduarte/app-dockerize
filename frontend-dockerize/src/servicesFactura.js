import axios from "axios";
const apiUrl = process.env.REACT_APP_API_URL;
export async function postFactura(Factura) {
  const baseUrl = `${apiUrl}/api/factura`;
  console.log(Factura);
  await axios
    .post(baseUrl, Factura)
    .then((response) => console.log("success full"))
    .catch((error) => console.log(error));
}
