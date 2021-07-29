import {
  Avatar,
  Button,
  Container,
  TextField,
  Typography,
  Grid,
  Card,
  CardMedia,
  CardContent,
  Box,
} from "@material-ui/core";
import React from "react";
import HttpsIcon from "@material-ui/icons/Https";
import style from "../Tools/Style";
import img from "../img/2.jpg"


const Login = () => {
  return (
    <Container maxWidth="sm">
      <Card style={style.root}>
        <CardMedia style={style.cover}>
          <img src={img} style={style.img}></img>
        </CardMedia>
        <div style={style.details}>
          <CardContent style={style.content}>
          <div style={style.paper}>
                      <Avatar style = {style.avatar}>
                         <HttpsIcon style={style.icon}></HttpsIcon>
                      </Avatar>
                      <Typography component= "h1" variant= "h5" >
                             Login
                      </Typography>
                      <form style= {style.form}>
                         <TextField variant= "outlined" label ="Ingrese su usuario" name="username" fullWidth  fullWidth margin="normal"></TextField>
                         <TextField variant= "outlined" type="password" label ="Ingrese su contraseña" name="contraseñá" fullWidth margin="normal" ></TextField>
                         <Button type="submit" fullWidth variant="contained" color="primary" style={style.submit} >Ingresar</Button>
                      </form>
                   </div>
          </CardContent>
        </div>
      </Card>
    </Container>
  );
};

export default Login;

/*<Container maxWidth="xs">
                   <div style={style.paper}>
                      <Avatar style = {style.avatar}>
                         <HttpsIcon style={style.icon}></HttpsIcon>
                      </Avatar>
                      <Typography component= "h1" variant= "h5" >
                             Login de Usuario
                      </Typography>
                      <form style= {style.form}>
                         <TextField variant= "outlined" label ="Ingrese su Username" name="username" fullWidth  fullWidth margin="normal"></TextField>
                         <TextField variant= "outlined" type="password" label ="Ingrese su Contraseña" name="contraseñá" fullWidth margin="normal" ></TextField>
                         <Button type="submit" fullWidth variant="contained" color="primary" style={style.submit} >Ingresar</Button>
                      </form>
                   </div>
             </Container>  */
