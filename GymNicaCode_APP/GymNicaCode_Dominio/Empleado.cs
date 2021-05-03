using System;
using System.Collections.Generic;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class Empleado
    {
        public Empleado()
        {
            Compras = new HashSet<Compra>();
            Facturas = new HashSet<Factura>();
            Usuarios = new HashSet<Usuario>();
        }

        public Guid IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? Telefono { get; set; }
        public string Cedula { get; set; }
        public bool? Estatus { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
