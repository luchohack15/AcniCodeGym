using GymNicaCode_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Contrato
{
   public interface IJwtGenerador
    {
        string CrearToken(Usuario usuario,List<string> roles);
    }
}
