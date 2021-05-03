using GymNicaCode_Aplicacion.ManejadorError;
using GymNicaCode_Dominio;
using GymNicaCode_Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Empleados
{

   public class Const_EmpleadoXid
    {
        public class EmpleadoXid : IRequest<Empleado>
        {
            public Guid Id { get; set; }
        }
        public class Manejador : IRequestHandler<EmpleadoXid, Empleado>
        {
            private readonly GymNicaCodeContext _context;
            public Manejador(GymNicaCodeContext context)
            {
                _context = context;
            }

            public async Task<Empleado> Handle(EmpleadoXid request, CancellationToken cancellationToken)
            {
                var query = await _context.Empleados.FindAsync(request.Id);
                if (query == null)
                {
                    // throw new Exception("No se encontro el empleado");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {Mensaje = "No se encontro el empleado" });
                }
                return query;
            }
        }
    }
}
