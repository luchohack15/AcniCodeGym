using System;
using System.Collections.Generic;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class Compra
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
        }

        public Guid IdCompra { get; set; }
        public Guid IdAlmacen { get; set; }
        public string NoFactura { get; set; }
        public DateTime? FechaCompra { get; set; }
        public Guid IdEmpleado { get; set; }
        public bool? Estatus { get; set; }

        public virtual Almacen IdAlmacenNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
