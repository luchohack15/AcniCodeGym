using GymNicaCode_Persistencia;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Seguridad.Roles
{
    public  class ListaDeRoles
    {
        public class ListaRoles : IRequest <List<IdentityRole>>{ }

        public class Manejador : IRequestHandler<ListaRoles, List<IdentityRole>>
        {

            private readonly GymNicaCodeContext _context;
            public Manejador(GymNicaCodeContext context)
            {
                _context = context;
            }
            public async Task<List<IdentityRole>> Handle(ListaRoles request, CancellationToken cancellationToken)
            {
               var roles = await _context.Roles.ToListAsync();
                return roles;
            }
        }
    }
}
