using GymNicaCode_Persistencia.DapperConexion.Producto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymNicaCode_Aplicacion.Productos
{
    public class ListaProducto
    {
        public class ObtenerListaProducto : IRequest<List<ProductoModel>> { }
        public class Manejador : IRequestHandler<ObtenerListaProducto, List<ProductoModel>>
        {
            private readonly IProducto _productoRepository;

            public Manejador(IProducto productoRepository)
            {
                _productoRepository = productoRepository;
            }
            public async Task<List<ProductoModel>> Handle(ObtenerListaProducto request, CancellationToken cancellationToken)
            {
                var resultado = await _productoRepository.ObtenerListaProducto();
                return resultado.ToList();
            }
        }
    }
}
