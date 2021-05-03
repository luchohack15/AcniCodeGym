using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class DetalleFactura
    {
        public Guid IdDetalleFactura { get; set; }
        public Guid IdFactura { get; set; }
        public Guid IdProducto { get; set; }
        [Column(TypeName = "decima(18,4)")]
        public decimal? Cantidad { get; set; }
        [Column(TypeName = "decima(18,4)")]
        public decimal? Precio { get; set; }
        public bool? Estatus { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
