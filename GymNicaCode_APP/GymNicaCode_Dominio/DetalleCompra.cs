using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class DetalleCompra
    {
        public Guid IdDetalleCompra { get; set; }
        public Guid IdCompra { get; set; }
        public Guid IdProducto { get; set; }
        [Column(TypeName = "decima(18,4)")]
        public decimal? Cantidad { get; set; }
        [Column(TypeName = "decima(18,4)")]
        public decimal? Costo { get; set; }
        [Column(TypeName = "decima(18,4)")]
        public decimal? MargenDeGanancia { get; set; }
        public bool? Estatus { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
