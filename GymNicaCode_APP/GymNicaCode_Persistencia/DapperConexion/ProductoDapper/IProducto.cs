using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Persistencia.DapperConexion.Producto
{
   public interface IProducto
    {
        Task<IEnumerable<ProductoModel>> ObtenerListaProducto();
        Task<ProductoModel> ObtenerProductoXId(Guid id);

        Task<int> GuardarProducto(string nombre, string descripcion,bool estatus);
        Task<int> EditarProducto(Guid idProducto, string nombre, string descripcion, bool estatus);
        Task<int> EliminarProducto(Guid id);
    }
}
