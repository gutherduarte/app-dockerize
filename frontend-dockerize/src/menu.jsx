import React, { useState, useEffect } from 'react';
import { makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import MenuCard from './menuCard';
import ShoppingCartIcon from "@material-ui/icons/ShoppingCart";
import Badge from "@material-ui/core/Badge";

const useStyles = makeStyles({
  root: {
    maxWidth: 300,
    maxHeight: 360,
    boxShadow: "1px 4.5px 4.5px rgba(0,0,0,0.3)",
  },
  center: {
    display: "flex",
    flexWrap: "nowrap",
    justifyContent: "space-around",
  },
  media: {
    height: 120,
  },
  tittle: {
    fontSize: "1.25rem",
    fontFamily: "Roboto, Helvetica, Arial, sans-serif",
    fontWeight: "bold",
    lineHeight: 1.6,
    letterSpacing: "0.0075em",
    color: "#3f51b5",
  },
  bar: {
    display: "flex",
    flexWrap: "nowrap",
    justifyContent: "space-around",
    backgroundColor: "rgba(190,190,190)",
    width: "89%",
    marginLeft: "auto",
    marginRight: "auto",
    borderRadius: "15px",
    marginBottom: "30px",
    marginTop: "20px",
  },
});

const Menu = (props) => {
  const apiUrl = "https://localhost:44347/";
  const { data, tittle } = props;
  const classes = useStyles();
 
  
  return (
    <>
      <div className={classes.bar}>
        <h1 className={classes.tittle}>{tittle}</h1>
        <Button size="small">
          <Badge badgeContent={5} color="secondary">
            <ShoppingCartIcon fontSize="large" color="primary" />
          </Badge>
        </Button>
      </div>
      <div className={classes.center}>
        {data
          ? data.map((info) => (
             <MenuCard info={info} classes={classes} />
            ))
          : null}
      </div>
    </>
  );
};
export default Menu;
