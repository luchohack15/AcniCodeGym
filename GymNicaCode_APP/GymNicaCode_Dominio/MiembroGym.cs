using System;
using System.Collections.Generic;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class MiembroGym
    {
        public MiembroGym()
        {
            DetalleMiembroGyms = new HashSet<DetalleMiembroGym>();
        }

        public Guid IdMiembroGym { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime? FechaComienzo { get; set; }
        public bool? Estatus { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<DetalleMiembroGym> DetalleMiembroGyms { get; set; }
    }
}
