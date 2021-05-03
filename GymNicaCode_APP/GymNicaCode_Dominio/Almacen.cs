using System;
using System.Collections.Generic;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class Almacen
    {
        public Almacen()
        {
            Compras = new HashSet<Compra>();
            Facturas = new HashSet<Factura>();
        }

        public Guid IdAlmacen { get; set; }
        public string NombreAlmacen { get; set; }
        public bool? Estatus { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
