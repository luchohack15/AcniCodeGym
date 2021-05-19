using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Persistencia.DapperConexion.Producto
{
   public  class ProductoModel
    {
        public Guid IdProdcuto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public bool? Estatus { get; set; }
    }
}
