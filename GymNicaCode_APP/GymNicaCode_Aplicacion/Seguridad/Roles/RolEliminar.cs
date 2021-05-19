using FluentValidation;
using GymNicaCode_Aplicacion.ManejadorError;
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
  public  class RolEliminar
    {
        public class Eliminar : IRequest
        {
            public string Nombre { get; set; }
        }
        public class ValidarRol : AbstractValidator<Eliminar>
        {
            public ValidarRol()
            {
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Eliminar>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            public Manejador (RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle(Eliminar request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(request.Nombre);
                if (role== null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No exite el rol" });
                }
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Unit.Value;
                }
                throw new Exception("Erro al eliminar");
            }
        }
    }
}
