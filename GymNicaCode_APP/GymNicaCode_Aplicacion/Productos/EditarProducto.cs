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
    public class EditarProducto
    {
        public class Editar : IRequest
        {
            public Guid IdProducto { get; set; }
            public string NombreProducto { get; set; }
            public string Descripcion { get; set; }
            public bool Estatus { get; set; }
        }
        public class EditarValidacion : AbstractValidator<Editar>
        {
            public EditarValidacion()
            {
                RuleFor(x => x.IdProducto).NotEmpty();
                RuleFor(x => x.NombreProducto).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estatus).NotEmpty();
            } 
        }
        public class Manejador : IRequestHandler<Editar>
        {
            private readonly IProducto _productoRepositorio;
            public Manejador (IProducto productoRepositotio)
            {
                _productoRepositorio = productoRepositotio;
            }
            public async Task<Unit> Handle(Editar request, CancellationToken cancellationToken)
            {
             var resultado = await _productoRepositorio.EditarProducto(request.IdProducto, request.NombreProducto, request.Descripcion, request.Estatus);
                if (resultado >0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se puede Actualizar");
            }
        }
    }
}
