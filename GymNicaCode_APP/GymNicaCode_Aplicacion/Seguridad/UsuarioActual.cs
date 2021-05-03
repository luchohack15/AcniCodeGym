using GymNicaCode_Aplicacion.Contrato;
using GymNicaCode_Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Seguridad
{
   public class UsuarioActual
    {
        public class UsuarioLogueado :IRequest<UsuarioData> { }

        public class Manejador : IRequestHandler<UsuarioLogueado, UsuarioData>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly IUsarioLogueado _usarioLogueado;
            public Manejador(UserManager<Usuario> userManager,IJwtGenerador jwtGenerador,IUsarioLogueado  usarioLogueado)
            {
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _usarioLogueado = usarioLogueado;
            }
            public async Task<UsuarioData> Handle(UsuarioLogueado request, CancellationToken cancellationToken)
            {
              var usuario = await  _userManager.FindByNameAsync(_usarioLogueado.ObetenerUsuariologueado());
                return new UsuarioData
                {
                    NombreEmpleado = "",
                    IdEmpleado = usuario.IdEmpleado,
                    UserName = usuario.UserName,
                    Email = usuario.Email,
                    Token = _jwtGenerador.CrearToken(usuario),
                    Imagen = null
                };
            }
        }
    }
}
