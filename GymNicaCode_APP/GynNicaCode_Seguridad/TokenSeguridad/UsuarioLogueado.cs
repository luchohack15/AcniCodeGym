using GymNicaCode_Aplicacion.Contrato;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GynNicaCode_Seguridad.TokenSeguridad
{
    public class UsuarioLogueado : IUsarioLogueado
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsuarioLogueado(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string ObetenerUsuariologueado()
        {
            var userName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }
    }
}
