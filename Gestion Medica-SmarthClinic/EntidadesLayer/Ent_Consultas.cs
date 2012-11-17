using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesLayer
{
    public class Ent_Consultas
    {

        public int IDPaciente { get; set; }
        public int IDMedico { get; set; }
        public string Motivo { get; set; }
        public string Diagnostico { get; set; }
        public static DateTime Fecha { get { return DateTime.Today; } }
    }
}
