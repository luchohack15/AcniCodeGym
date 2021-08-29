import axios from 'axios';

axios.defaults.baseURL ='https://localhost:44391/api';
axios.interceptores.request.use((config) =>{
   const token_seguridad = window.localStorage.getItem('token_seguridad');
   if (token_seguridad){
        config.headers.Autorization = 'Bearer ' + token_seguridad;
        return config;
   }
}, error =>{
     return Promise.reject(error);
});

const requestGenerico = {
  get : (url) => axios.get(url),
  post : (url,body) => axios.post(url,body),
  put : (url,body) => axios.put(url,body)
};

export default requestGenerico;