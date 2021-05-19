using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Persistencia.DapperConexion.Producto
{
    public class ProductoRepositorio : IProducto
    {
        private readonly IFactoryConnection _factoryConnection;

        public ProductoRepositorio(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }
        public async Task<int> EditarProducto(Guid idProducto, string nombre, string descripcion, bool estatus)
        {
            var storeProcedure = "SpEditarProducto";
            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(
                       storeProcedure,
                          new
                          {
                              IdProducto = idProducto,
                              NombreProducto = nombre,
                              Descripcion = descripcion,
                              Estatus = estatus
                          },
                          commandType: CommandType.StoredProcedure
                     );
                _factoryConnection.CloseConnection();
                return resultado;
            }
            catch (Exception e)
            {

                throw new Exception("error al Editar", e);
            }
        }

        public Task<int> EliminarProducto(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GuardarProducto(string nombre, string descripcion, bool estatus)
        {
            try
            {
                var storeProcedure = "SpCrearProducto";
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    IdProducto = Guid.NewGuid(),
                    NombreProducto = nombre,
                    Descripcion = descripcion,
                    Estatus = estatus
                }, commandType: CommandType.StoredProcedure);
                _factoryConnection.CloseConnection();
                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception("error al guardar", e);
            }
        }

        public async Task<IEnumerable<ProductoModel>> ObtenerListaProducto()
        {
            IEnumerable<ProductoModel> productoList = null;
            var storeProcedure = "SpListaDeProducto";
            try
            {
                var conexion = _factoryConnection.GetConnection();
                productoList = await conexion.QueryAsync<ProductoModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception("Error al Cargar", e);

            }
            finally
            {
                _factoryConnection.CloseConnection();
            }
            return productoList;
        }

        public Task<ProductoModel> ObtenerProductoXId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
