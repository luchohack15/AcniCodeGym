using FluentValidation;
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
    public class CrearProducto
    {
        public class Crear : IRequest{
           public string NombreProducto { get; set; }
           public string Descripcion { get; set; }
           public bool Estatus { get; set; }
        }
        public class CrearValidar : AbstractValidator<Crear>
        {
            public CrearValidar()
            {
                RuleFor(x => x.NombreProducto).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estatus).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Crear>
        {
            private readonly IProducto _productoRepository;
            public Manejador (IProducto productoRepository)
            {
                _productoRepository = productoRepository;
            }
            public async Task<Unit> Handle(Crear request, CancellationToken cancellationToken)
            {
               var resultado = await _productoRepository.GuardarProducto(request.NombreProducto, request.Descripcion,request.Estatus);
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insert el producto");
            }
        }
    }
}
