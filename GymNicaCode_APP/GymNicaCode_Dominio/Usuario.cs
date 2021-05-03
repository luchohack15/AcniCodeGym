using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class Usuario: IdentityUser
    {
        //public Guid IdUsuario { get; set; }
        public Guid IdEmpleado { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}
