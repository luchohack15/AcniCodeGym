using FluentValidation;
using GymNicaCode_Aplicacion.Contrato;
using GymNicaCode_Aplicacion.Empleados;
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

namespace GymNicaCode_Aplicacion.Seguridad
{
  public  class Login
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class Validacion : AbstractValidator<Ejecuta>
        {
            public Validacion()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly SignInManager<Usuario> _signInManager;
            private readonly IJwtGenerador _jwtGenerador;
            public Manejador(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager,IJwtGenerador jwtGenerador) 
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerador = jwtGenerador;
            }
            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Unauthorized);
                }
                var query = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);
                var resultadoRoles = await _userManager.GetRolesAsync(usuario);
                var listaRoles = new List<string>(resultadoRoles);
                if (query.Succeeded)
                {
                    return new UsuarioData
                    {
                        NombreEmpleado = "falta implementar",
                        IdEmpleado = usuario.IdEmpleado,
                        Token = _jwtGenerador.CrearToken(usuario,listaRoles),
                        UserName = usuario.UserName,
                        Email =usuario.Email,
                        Imagen = null

                    };
                }
                throw new ManejadorExcepcion(HttpStatusCode.Unauthorized);
            }

            
        }
    }
}
