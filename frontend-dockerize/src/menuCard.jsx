import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import Typography from "@material-ui/core/Typography";
import AddShoppingCartIcon from "@material-ui/icons/AddShoppingCart";
import Button from "@material-ui/core/Button";
import React, { useState } from 'react'
import {postFactura} from "./servicesFactura"

const MenuCard = (props) => {
    const {info,classes}=props
    const [detalle, setDetalle] = useState([]);
    const apiUrl = "https://localhost:44347/";
    const fechaD = new Date();
    
  console.log(info);
    const handleFactura=()=>{
        
       const facturaDetalles={productoID:info.productoID};
       setDetalle((prevDetalle) => [...prevDetalle, facturaDetalles]);
      const Factura={ClienteID:"69289A27-78EE-44B6-8A14-1086BF904FB8",Total:info.precio,Fecha:`${fechaD.getFullYear()}-${
        parseInt(fechaD.getMonth()) + 1
      }-${fechaD.getDate()}`,facturaDetalles:detalle}
      console.log(Factura)
      postFactura(Factura);
    }

    return ( <>
             <Card className={classes.root}>
                <CardActionArea>
                  <CardMedia
                    component="img"
                    className={classes.media}
                    alt={info.nombre}
                    image={`${apiUrl}${info.imagen}`}
                  />
                  <CardContent>
                    <Typography gutterBottom variant="h5" component="h2">
                      {info.Producto}
                    </Typography>
                    <Typography>{`C$ ${info.precio}`}</Typography>
                    <Typography
                      variant="body2"
                      color="textSecondary"
                      component="p"
                    >
                      {info.descripcion}
                    </Typography>
                  </CardContent>
                </CardActionArea>
                <CardActions>
                  <Button size="small" color="primary">
                    <AddShoppingCartIcon onClick={handleFactura}  />
                  </Button>
                  <Button size="small" color="primary">
                    <strong>Leer más</strong>
                  </Button>
                </CardActions>
              </Card>
          </>
         );
}
 
export default MenuCard;