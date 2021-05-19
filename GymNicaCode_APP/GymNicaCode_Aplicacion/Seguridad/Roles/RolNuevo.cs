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

namespace GymNicaCode_Aplicacion.Seguridad
{
    public class RolNuevo
    {
        public class CrearRol : IRequest
        {
            public string Nombre { get; set; }
        }
        public class validaEjecuta: AbstractValidator<CrearRol>
        {
            public validaEjecuta()
            {
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<CrearRol>
        {
            private readonly RoleManager<IdentityRole> _rolManager;
            public Manejador(RoleManager<IdentityRole> rolManager)
            {
                _rolManager = rolManager;
            }
            public async Task<Unit> Handle(CrearRol request, CancellationToken cancellationToken)
            {
                var role = await _rolManager.FindByNameAsync(request.Nombre);
                if (role != null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new  { mensaje = "Ya existe el rol" });
                }
               var reulst = await _rolManager.CreateAsync(new IdentityRole(request.Nombre));
                if (reulst.Succeeded)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo crear el rol");
            }
        }
    }
}
