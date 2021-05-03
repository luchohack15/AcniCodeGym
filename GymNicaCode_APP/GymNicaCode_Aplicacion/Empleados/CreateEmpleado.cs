using GymNicaCode_Persistencia;
using GymNicaCode_Dominio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace GymNicaCode_Aplicacion.Empleados
{
    public class CreateEmpleado
    {
        public class Create: IRequest
        {
           
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public int? Telefono { get; set; }
            public string Cedula { get; set; }
            public bool? Estatus { get; set; }
        }
        public class CreateValidacion : AbstractValidator<Create>
        {
            public CreateValidacion()
            {
                RuleFor(x => x.Nombres).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
                RuleFor(x => x.Cedula).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Create>
        {
            private readonly GymNicaCodeContext _context;
             public Manejador(GymNicaCodeContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Create request, CancellationToken cancellationToken)
            {
                        Guid _IdEmpelado = Guid.NewGuid();
                var query = new Empleado
                {
                        IdEmpleado = _IdEmpelado,
                        Nombres = request.Nombres,
                        Apellidos = request.Apellidos,
                        Cedula = request.Cedula,
                        Telefono = request.Telefono,
                        Estatus = request.Estatus
                    };
                    _context.Empleados.Add(query);
                  var valor =  await _context.SaveChangesAsync();
                    if (valor > 0)
                    {
                        return Unit.Value;
                    }
                throw new Exception("No se pudo insert el empleado");
                
            }
        }
    }
}
