using GymNicaCode_Persistencia.Paginacion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Empleados
{
    public class PaginacionEmpleado
    {
        public class Ejecuta : IRequest<PaginacionModel>
        {
            public string Nombres { get; set;}
            public int NumeroPagina { get; set; }
            public int CantidadElementos { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, PaginacionModel>
        {
            private readonly IPaginacion _paginacion;
            public Manejador(IPaginacion paginacion)
            {
                _paginacion = paginacion;
            }
            public async Task<PaginacionModel> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var storedProcedure = "SpPaginarEmpleado";
                var ordenamiento = "Nombres";
                var parametros = new Dictionary<string, object>();
                parametros.Add("Nombres", request.Nombres);
                return await _paginacion.DevolverPaginacion(storedProcedure, request.NumeroPagina, request.CantidadElementos, parametros, ordenamiento);
            }
        }
    }
}
