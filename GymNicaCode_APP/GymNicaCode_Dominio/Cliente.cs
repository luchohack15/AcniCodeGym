using System;
using System.Collections.Generic;

#nullable disable

namespace GymNicaCode_Dominio
{ 
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
            MiembroGyms = new HashSet<MiembroGym>();
            RegistroEntradaClientes = new HashSet<RegistroEntradaCliente>();
        }

        public Guid IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidosCliente { get; set; }
        public int? Telefono { get; set; }
        public string Correo { get; set; }
        public string Cedula { get; set; }
        public byte[] FotoCliente { get; set; }
        public string ClaveDeAcceso { get; set; }
        public bool? Estatus { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<MiembroGym> MiembroGyms { get; set; }
        public virtual ICollection<RegistroEntradaCliente> RegistroEntradaClientes { get; set; }
    }
}
