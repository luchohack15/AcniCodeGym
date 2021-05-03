using System;
using System.Collections.Generic;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class RegistroEntradaCliente
    {
        public Guid IdRegistroEntradaCliente { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public bool? Estatus { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
