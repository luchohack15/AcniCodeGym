using FluentValidation;
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
    public class UsuarioRolEliminar
    {
        public class DeleteUsuarioRol : IRequest
        {
            public string Username { get; set; }
            public string RolNombre { get; set; }
        }
        public class EjecutaValidador : AbstractValidator<DeleteUsuarioRol>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.RolNombre).NotEmpty();
            }
        } 
        public class Manejador : IRequestHandler<DeleteUsuarioRol>
        {
            private readonly UserManager<Usuario> _userManager;

            private readonly RoleManager<IdentityRole> _roleManager;

            public Manejador(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle(DeleteUsuarioRol request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(request.RolNombre);
                if (role == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "el rol no existe" });
                }
                var usuario = await _userManager.FindByNameAsync(request.Username);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "el usuario no existe" });
                }
                var resultado = await _userManager.RemoveFromRoleAsync(usuario, request.RolNombre);
                if (resultado.Succeeded)
                {
                    return Unit.Value;
                }
                throw new Exception("No se puedo Eliminar el rol");
            }
        }
    }
}
