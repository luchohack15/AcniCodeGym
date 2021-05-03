using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Seguridad
{
   public class UsuarioData
    { 
        public string NombreEmpleado { get; set; }
        public Guid IdEmpleado { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Imagen { get; set; }

    }
}
