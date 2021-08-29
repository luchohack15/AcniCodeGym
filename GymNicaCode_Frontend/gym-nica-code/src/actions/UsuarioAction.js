import HttpCliente from '../servicios/HttpCliente';
//import { promised } from 'q';


export const registarUsuarios = usuario =>{
    return new Promise ((resolve,eject) => {
        HttpCliente.post('/Usuario/crear',usuario).then(reponse => {
            resolve(reponse);
        })
    })
}