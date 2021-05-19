import { Button, Container, Grid, TextField, Typography } from '@material-ui/core';
import React from 'react'; 

const style = {
    paper:{
             marginTop: 8,
             display : "flex",
             flexDirection :  "column",
             alignItems : "center"
      },
      from:{
            width: "100%",
            marginTop: 20
      } ,
      submit : {
          marginTop : 15
      }
};


const RegistrarUsuario = () =>{
      return (
          <Container component="main" maxWidth="md" justify="center">
           <div style={style.paper}>
                <Typography component="h1" variant="h5">
                    Registar Usuario
                </Typography>
                <form style={style.from}>
                  <Grid container spacing={2}>
                      <Grid item xs={12} md={6}>
                           <TextField name="nombre" variant="outlined" fullWidth label="Ingrese su nombre"></TextField>
                      </Grid>
                      <Grid item xs={12} md={6}>
                           <TextField name="apellido" variant="outlined" fullWidth label="Ingrese su apellido"></TextField>
                      </Grid>
                      <Grid item xs={12} md={6}>
                           <TextField name="email" type="email" variant="outlined" fullWidth label="Ingrese su correo"></TextField>
                      </Grid>
                      <Grid item xs={12} md={6}>
                           <TextField name="username" variant="outlined" fullWidth label="Ingrese su UserName"></TextField>
                      </Grid>
                      <Grid item xs={12} md={6}>
                           <TextField name="password" type="password" variant="outlined" fullWidth label="Ingrese su Contraseña"></TextField>
                      </Grid>
                      <Grid item xs={12} md={6}>
                           <TextField name="confirmaPassword" type="password" variant="outlined" fullWidth label="Confirme su contraseña"></TextField>
                      </Grid>
                  </Grid>
                  <Grid container justify="center">
                      <Grid item xs={12} md={6}>
                         <Button type="submit" fullWidth  variant="contained" color= "primary" size="large" style={style.submit} >Guardar</Button>
                      </Grid>

                  </Grid>
                </form>
           </div>
          </Container>
      );
}

export default RegistrarUsuario;