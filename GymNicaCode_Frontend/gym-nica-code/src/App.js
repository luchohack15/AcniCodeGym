import React from 'react';
import { ThemeProvider } from '@material-ui/core/styles';
import theme from './theme/theme';
import RegistarUsuario from './componentes/Seguridad/RegistrarUsuario';
//import Login from './componentes/Seguridad/Login';
function App() {
   return(
     <ThemeProvider theme={theme}>
        <RegistarUsuario></RegistarUsuario>
     </ThemeProvider>
   );
}
 
export default App;
