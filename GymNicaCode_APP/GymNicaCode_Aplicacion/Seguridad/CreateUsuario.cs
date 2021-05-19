using FluentValidation;
using GymNicaCode_Aplicacion.Contrato;
using GymNicaCode_Aplicacion.ManejadorError;
using GymNicaCode_Dominio;
using GymNicaCode_Persistencia;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Seguridad
{
    public class CreateUsuario
    {
        public class create : IRequest<UsuarioData>
        {
            public Guid IdEmpleado { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class createValidador : AbstractValidator<create>
        {
            public createValidador(){
                RuleFor(x => x.IdEmpleado).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<create,UsuarioData>
        {
            private readonly GymNicaCodeContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;

            public Manejador(GymNicaCodeContext context, UserManager<Usuario> userManager,IJwtGenerador jwtGenerador)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
            }
            public async Task<UsuarioData> Handle(create request, CancellationToken cancellationToken)
            {
                var existe = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();
                if (existe)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "Ya Existe un usuario registrado con ese Email" });
                }

                var existeUserName = await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync();
                if (existeUserName)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "Ya Existe un usuario registrado con ese Usuername" });
                }
                var existeEmpleado = await _context.Users.Where(x => x.IdEmpleado == request.IdEmpleado).AnyAsync();
                if (existeEmpleado == false)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "El Empleado no existe" });
                }
                var usuario = new Usuario
                {
                    IdEmpleado = request.IdEmpleado,
                    Email = request.Email,
                    UserName =request.UserName
                
                };
               var resultado = await _userManager.CreateAsync(usuario, request.Password);
                if (resultado.Succeeded)
                {
                    return new UsuarioData
                    {
                        UserName = usuario.UserName,
                        Email = usuario.Email,
                        Token = _jwtGenerador.CrearToken(usuario,null)
                    };
                }
                throw new Exception("Error al agregar al nuevo Usuario");
            }
        }
    }
}
