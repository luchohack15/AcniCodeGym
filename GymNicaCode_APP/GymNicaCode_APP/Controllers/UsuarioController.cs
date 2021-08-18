
using GymNicaCode_Aplicacion.Seguridad;
using GymNicaCode_Aplicacion.Seguridad.Roles;
using GymNicaCode_Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymNicaCode_APP.Controllers
{
    [AllowAnonymous]
    public class UsuarioController : MyControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioData>> Login([FromBody] Login.IniciarSesion parametros)
        {
            return await Mediator.Send(parametros);
        }
        [HttpPost("crear")]
        public async Task<ActionResult<UsuarioData>> crear(CreateUsuario.create parametros)
        {
            return await Mediator.Send(parametros);
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioData>> UsuarioActual()
        {
            return await Mediator.Send(new UsuarioActual.UsuarioLogueado());
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioData>> UsuarioActualizar(UsuarioActualizar.UpdateUsuario parametros)
        {
            return await Mediator.Send(parametros);
        }

    }
}
 