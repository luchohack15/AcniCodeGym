using System;
using System.Collections.Generic;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public Guid IdFactura { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdAlmacen { get; set; }
        public Guid IdEmpleado { get; set; }
        public string NoFactura { get; set; }
        public DateTime? FechaFactura { get; set; }
        public bool? Estatus { get; set; }

        public virtual Almacen IdAlmacenNavigation { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
