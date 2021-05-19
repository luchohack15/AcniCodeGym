using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Persistencia.Paginacion
{
   public interface IPaginacion
    {
        Task<PaginacionModel> DevolverPaginacion(string storeProdecure, int numeroPagina ,int CantidadElementos, IDictionary<string, object> parametrosFiltro,string ordenamientoColumna);
    }
}
