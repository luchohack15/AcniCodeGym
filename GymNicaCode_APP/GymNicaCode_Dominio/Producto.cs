using System;
using System.Collections.Generic;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public Guid IdProdcuto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public bool? Estatus { get; set; }

        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
