using AutoMapper;
using GymNicaCode_Aplicacion.Empleados;
using GymNicaCode_Aplicacion.Seguridad;
using GymNicaCode_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Empleado, EmpleadoDto>();
        }

    }
}
