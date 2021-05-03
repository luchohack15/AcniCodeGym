using GymNicaCode_Dominio;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Persistencia
{
   public class DataPrueba
    {
        public static async Task InsertarData(GymNicaCodeContext context, UserManager<Usuario> userManager)
        {
             if (!userManager.Users.Any())
            {
                Guid idempleado = context.Empleados.Select(x => x.IdEmpleado).FirstOrDefault();
                var usuario = new Usuario
                {
                  
                    UserName = "Soporte",
                    Email = "franciscorios@gmail.com",
                    IdEmpleado = idempleado
                };
                await userManager.CreateAsync(usuario, "Password123$");
            }

        }
    }
}
