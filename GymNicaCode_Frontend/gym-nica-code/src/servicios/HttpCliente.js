import axios from 'axios';

axios.defaults.baseURL ='https://localhost:44391/api';

const requestGenerico = {
  get : (url) => axios.get(url),
  post : (url,body) => axios.post(url,body),
  put : (url,body) => axios.put(url,body)
};

export default requestGenerico;