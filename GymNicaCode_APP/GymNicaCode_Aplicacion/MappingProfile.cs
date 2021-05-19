using AutoMapper;
using GymNicaCode_Aplicacion.Empleados;
using GymNicaCode_Aplicacion.Seguridad;
using GymNicaCode_Dominio;
using GymNicaCode_Persistencia.DapperConexion.Producto;
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
            CreateMap<Producto, ProductoModel>();
        }

    }
}
