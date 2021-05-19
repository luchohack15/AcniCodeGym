using GymNicaCode_Aplicacion.Productos;
using GymNicaCode_Persistencia.DapperConexion.Producto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymNicaCode_APP.Controllers
{
    public class ProductoController : MyControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductoModel>>> ObtenerProducto(){
            return await Mediator.Send(new ListaProducto.ObtenerListaProducto());
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> CrearProducto(CrearProducto.Crear data)
        {
            return await Mediator.Send(data);
        }
        [HttpPut("{Id}")]
        public async Task <ActionResult<Unit>> EditarProducto(Guid Id, EditarProducto.Editar data)
        {
            data.IdProducto = Id;
            return await Mediator.Send(data);
        }
    }
}
