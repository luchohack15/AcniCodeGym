using System;
using System.Collections.Generic;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class DetalleMiembroGym
    {
        public Guid IdDetalleMiembroGym { get; set; }
        public Guid IdMiembroGym { get; set; }
        public Guid IdMembresia { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool? Estatus { get; set; }

        public virtual Membresium IdMembresiaNavigation { get; set; }
        public virtual MiembroGym IdMiembroGymNavigation { get; set; }
    }
}
