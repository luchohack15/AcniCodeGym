using GymNicaCode_Aplicacion.Seguridad;
using GymNicaCode_Aplicacion.Seguridad.Roles;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymNicaCode_APP.Controllers.Rol
{
    public class RolController : MyControllerBase
    {
        [HttpPost("crearRol")]
        public async Task<ActionResult<Unit>> CrearRol(RolNuevo.CrearRol data)
        {
            return await Mediator.Send(data);
        }
        [HttpDelete("EliminarRol")]
        public async Task<ActionResult<Unit>> Eliminar(RolEliminar.Eliminar data)
        {
            return await Mediator.Send(data);
        }
        [HttpGet("ObetnerRoles")]
        public async Task<ActionResult<List<IdentityRole>>> Lista()
        {
            return await Mediator.Send(new ListaDeRoles.ListaRoles());
        }
        [HttpPost("AgregarRolUsuario")]
        public async Task<ActionResult<Unit>> AgregarRolUsuario(UsuarioRolAgregar.Ejecuta paramtros)
        {
            return await Mediator.Send(paramtros);
        }

        [HttpPost("EliminarRolUsuario")]
        public async Task<ActionResult<Unit>> EliminarRolUsuario(UsuarioRolEliminar.Ejecuta paramtros)
        {
            return await Mediator.Send(paramtros);
        }
        [HttpGet("{UserName}")]
        public async Task<ActionResult<List<string>>> ObtenerRolUsuario(string userName)
        {
            return await Mediator.Send(new ObtenerRolesPorUsuario.Ejecuta { Username = userName });
        }
    }
}
