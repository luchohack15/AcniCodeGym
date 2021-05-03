using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Empleados
{
   public class EmpleadoDto
    {
        public Guid IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? Telefono { get; set; }
        public string Cedula { get; set; }
        public bool? Estatus { get; set; }
    }
}
