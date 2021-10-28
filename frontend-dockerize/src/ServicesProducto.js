import axios from "axios";
const apiUrl = process.env.REACT_APP_API_URL;

export const GetProducto = () => {
  const baseUrl = `${apiUrl}/api/producto`;
  return fetch(baseUrl)
    .then((res) => res.json())
    .then((response) => {
      const data = ([] = [...response]);
      console.log(data);
      return data;
    })
    .catch((error) => {
      console.log(error);
    });
};

function request(Producto, method) {
  const requestOptions = {
    method,
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(Producto),
  };
  return requestOptions;
}

export async function PostProduto(Producto) {
  const baseUrl = `${apiUrl}/api/producto`;
  console.log(Producto);
  await axios
    .post(baseUrl, Producto)
    .then((response) => console.log("success full" + response))
    .catch((error) => console.log(error));
}

export async function PutProducto(Producto = {}, ID) {
  const baseUrl = `${apiUrl}/api/producto/ ${ID}`;
  const response = await fetch(baseUrl, {
    method: "POST",
    mode: "cors",
    cache: "no-cache",
    credentials: "same-origin",
    headers: {
      "Content-Type": "application/json",
    },
    redirect: "follow",
    referrerPolicy: "no-referrer",
    body: JSON.stringify(Producto),
  });
  return response.json();
}

export async function DeleteProducto(ID) {
  const baseUrl = `${apiUrl}/api/producto/${ID}`;
  const response = await fetch(baseUrl, {
    method: "Delete",
  });
  return response.json();
}

export const fetchProducto = {
  GetProducto,
  PostProduto,
  PutProducto,
  DeleteProducto,
};
