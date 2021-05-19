using GymNicaCode_Aplicacion.Contrato;
using GymNicaCode_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace GynNicaCode_Seguridad.TokenSeguridad
{
    public class JwtGenerador : IJwtGenerador
    {
        private readonly AppSetting _appSetting;
        public JwtGenerador(IOptions<AppSetting> appSettings)
        {
            _appSetting = appSettings.Value;
        }
        public string CrearToken(Usuario usuario,List<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,usuario.UserName )
            };

            if (roles!= null)
            {
                foreach (var rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
            }

            var key = Encoding.ASCII.GetBytes(_appSetting.Secreto);
            var credenciales = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescripcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credenciales
            };

            var tokenManejador = new JwtSecurityTokenHandler();
            var token = tokenManejador.CreateToken(tokenDescripcion);
            return tokenManejador.WriteToken(token);
        }
    }
}  
