import { Button, Container, Grid, TextField, Typography } from '@material-ui/core';
import React, { useState } from 'react'; 
import style from '../Tools/Style';
import { registarUsuarios } from '../../actions/UsuarioAction';

const RegistrarUsuario = () =>{
    const [usuario,setUsuario] = useState({
        IdEmpleado : '',
        UserName :'',
        Email : '',
        Password : '',
        ConfirmaPassword : ''
    })

    const ingresarValoresMemoria = e =>{
      const {name, value} = e.target;
      setUsuario( anterior =>({
          ...anterior,
          [name] : value
      }))
    }

    const registrarUsuarioBoton = e =>{
        e.preventDefault();
        //console.log(usuario);
        registarUsuarios(usuario).then(response => {
            console.log('se registro existosamente el usuario',response);
            window.localStorage.setItem("token_seguridad",response.data.token);
        })
    }
      return (
          <Container component="main" maxWidth="md" justify="center">
           <div style={style.paper}>
                <Typography component="h1" variant="h5">
                    Registar Usuario
                </Typography>
                <form style={style.form}>
                  <Grid container spacing={2}>
                      <Grid item xs={12} md={6}>
                           <TextField name="IdEmpleado" value={usuario.IdEmpleado} onChange={ingresarValoresMemoria} variant="outlined" fullWidth label="Ingrese su nombre"></TextField>
                      </Grid>
                      <Grid item xs={12} md={6}>
                           <TextField name="UserName" value={usuario.UserName} onChange={ingresarValoresMemoria} variant="outlined" fullWidth label="Ingrese su username"></TextField>
                      </Grid>
                      <Grid item xs={12} md={6}>
                           <TextField name="Email" value={usuario.Email} onChange={ingresarValoresMemoria} type="email" variant="outlined" fullWidth label="Ingrese su correo"></TextField>
                      </Grid>
                      <Grid item xs={12} md={6}>
                           <TextField name="Password" value={usuario.Password} onChange={ingresarValoresMemoria} type="password" variant="outlined" fullWidth label="Ingrese su Contraseña"></TextField>
                      </Grid>
                      <Grid item xs={12} md={12}>
                           <TextField name="ConfirmaPassword" value={usuario.ConfirmaPassword} onChange={ingresarValoresMemoria} type="password" variant="outlined" fullWidth label="Confirme su contraseña"></TextField>
                      </Grid>
                  </Grid>
                  <Grid container justify="center">
                      <Grid item xs={12} md={6}>
                         <Button type="submit" onClick={registrarUsuarioBoton} fullWidth  variant="contained" color= "primary" size="large" style={style.submit} >Guardar</Button>
                      </Grid>

                  </Grid>
                </form>
           </div>
          </Container>
      );
}

export default RegistrarUsuario;