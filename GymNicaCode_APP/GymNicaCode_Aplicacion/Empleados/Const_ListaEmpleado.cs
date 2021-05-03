using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNicaCode_Dominio;
using GymNicaCode_Persistencia;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace GymNicaCode_Aplicacion.Empleados
{
    public class Const_ListaEmpleado
    {
        public class ListaEmpleado: IRequest<List<EmpleadoDto>>{}
        public class Manejador : IRequestHandler<ListaEmpleado, List<EmpleadoDto>>
        {
            private readonly GymNicaCodeContext _context;
            private readonly IMapper _mapper;
            public Manejador(GymNicaCodeContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            } 
            public  async  Task<List<EmpleadoDto>> Handle(ListaEmpleado request, CancellationToken cancellationToken)
            {
                var query = await _context.Empleados.ToListAsync();

                var empleadoDto = _mapper.Map<List<Empleado>, List<EmpleadoDto>>(query);
                return empleadoDto;
            }
        }
    }
}
