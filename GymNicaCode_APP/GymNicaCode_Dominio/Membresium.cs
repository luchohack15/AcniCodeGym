using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GymNicaCode_Dominio
{
    public partial class Membresium
    {
        public Membresium()
        {
            DetalleMiembroGyms = new HashSet<DetalleMiembroGym>();
        }

        public Guid IdMembresia { get; set; }
        public string NombreMembresia { get; set; }
        [Column(TypeName  = "decima(18,4)")]
        public decimal? Precio { get; set; }
        public string TipoMembresia { get; set; }
        public int? Dias { get; set; }
        public int? Semana { get; set; }
        public int? Meses { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }
        public bool? Estats { get; set; }

        public virtual ICollection<DetalleMiembroGym> DetalleMiembroGyms { get; set; }
    }
}
