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
    public class UsuarioActualizar
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public Guid IdEmpleado { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.IdEmpleado).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly GymNicaCodeContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly IPasswordHasher<Usuario> _passwordHasher;
            public Manejador(GymNicaCodeContext context,UserManager<Usuario> userManager,IJwtGenerador jwtGenerador, IPasswordHasher<Usuario> passwordHasher)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _passwordHasher = passwordHasher; 
            }
            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuarioId = await _userManager.FindByNameAsync(request.UserName);
                if (usuarioId == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { Mensaje = "No existe un usuario con ese un username" });
                }
                 var resultado = await  _context.Users.Where(x => x.Email == request.Email && x.UserName != request.UserName).AnyAsync();
                if (resultado)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.InternalServerError, new { Mensaje = "Este Email ya esta en uso" });
                }
                usuarioId.IdEmpleado = request.IdEmpleado;
                usuarioId.PasswordHash = _passwordHasher.HashPassword(usuarioId, request.Password);
                usuarioId.Email = request.Email;

               var relsult= await _userManager.UpdateAsync(usuarioId);
               var roles = await _userManager.GetRolesAsync(usuarioId);
                var lisRoles = new List<string>(roles);
                if (relsult.Succeeded)
                {
                    return new UsuarioData
                    {
                        IdEmpleado = usuarioId.IdEmpleado,
                        UserName = usuarioId.UserName,
                        Email = usuarioId.Email,
                        Token = _jwtGenerador.CrearToken(usuarioId,lisRoles)
                    };
                }
                throw new Exception("No se pudo Actulizar");
            }
        }
    }
}
