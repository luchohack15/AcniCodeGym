using FluentValidation;
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
   public class UpdateEmpleado
    {
        public class Update :IRequest
         {
            public Guid IdEmpleado { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public int? Telefono { get; set; }
            public string Cedula { get; set; }
            public bool? Estatus { get; set; }
        }
        public class CreateValidacion : AbstractValidator<Update>
        {
            public CreateValidacion()
            {
                RuleFor(x => x.Nombres).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
                RuleFor(x => x.Cedula).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Update>
        {

            private readonly GymNicaCodeContext _context;
            public  Manejador(GymNicaCodeContext context) 
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(Update request, CancellationToken cancellationToken)
            {
                var query = await _context.Empleados.FindAsync(request.IdEmpleado);
                if (query == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { Mensaje = "No se encontro el empleado" });
                }
                query.Nombres = request.Nombres ?? query.Nombres;
                query.Apellidos = request.Apellidos ?? query.Apellidos;
                query.Cedula = request.Cedula ?? query.Cedula;
                query.Telefono = request.Telefono ?? query.Telefono;
                query.Estatus = request.Estatus ?? query.Estatus;
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;    
                }
                throw new Exception("error al actualizar");
            }
        }
    }
       
}    

