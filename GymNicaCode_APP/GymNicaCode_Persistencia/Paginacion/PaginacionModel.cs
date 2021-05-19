﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode_Persistencia.Paginacion
{
   public class PaginacionModel
    {
        public List<IDictionary<string,object>> ListaRecords { get; set; } 
        public int TotalRecords { get; set; }
        public int NumeroPaginas { get; set;}
    }
}
