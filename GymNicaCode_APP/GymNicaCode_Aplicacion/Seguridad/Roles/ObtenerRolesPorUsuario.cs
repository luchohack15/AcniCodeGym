using GymNicaCode_Aplicacion.ManejadorError;
using GymNicaCode_Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Seguridad.Roles
{
    public class ObtenerRolesPorUsuario
    {
        public class GetRolesPorUsuario : IRequest<List<string>>
        {
            public string Username { get; set; }
        }

        public class Manejador : IRequestHandler<GetRolesPorUsuario, List<string>>
        {
            private readonly UserManager<Usuario> _userManager;

            private readonly RoleManager<IdentityRole> _roleManager;
            public Manejador(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }
            public  async Task<List<string>> Handle(GetRolesPorUsuario request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByNameAsync(request.Username);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "el usuario no existe" });
                }
                var resultado = await _userManager.GetRolesAsync(usuario);
                return new List<string>(resultado);
            }
        }
    }
}
