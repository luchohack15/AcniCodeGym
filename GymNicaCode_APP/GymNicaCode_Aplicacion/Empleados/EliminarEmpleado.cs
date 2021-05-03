using GymNicaCode_Aplicacion.ManejadorError;
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
    public class EliminarEmpleado
    {
        public class Eliminar : IRequest
        {
            public Guid IdEmpleado { get; set; }
        }
        public class Manejador : IRequestHandler<Eliminar>
        {

            private readonly GymNicaCodeContext _context;
            public Manejador(GymNicaCodeContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Eliminar request, CancellationToken cancellationToken)
            {
                var query = await _context.Empleados.FindAsync(request.IdEmpleado);
                if (query == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { Mensaje = "No se encontro el empleado" });
                }
                query.Estatus = false;
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("error al Eliminar");
            }
        }
}
}