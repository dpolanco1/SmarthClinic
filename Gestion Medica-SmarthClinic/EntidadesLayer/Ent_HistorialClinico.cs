using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesLayer
{
  public  class Ent_HistorialClinico
    {
        public int IDHistorial { get; set; }
        public int IDPaciente { get; set; }
        public string RemitidoPor { get; set; }
        public string SintomasEvoluciones { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
