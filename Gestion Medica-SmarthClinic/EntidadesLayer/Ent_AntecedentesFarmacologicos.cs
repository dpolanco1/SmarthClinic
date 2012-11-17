using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesLayer
{
    public class Ent_AntecedentesFarmacologicos
    {
        public int IDAntecedenteFarmacologico { get; set; }
        public int IDHistorial { get; set; }
        public bool AntiHipertensivos { get; set; }
        public bool AntiPlaquetarios { get; set; }
        public bool AntiCoagulante { get; set; }
        public bool AntiArritmico { get; set; }
        public bool Antibioticos { get; set; }
        public bool Antiflamatorios { get; set; }
        public bool Esteroides { get; set; }
        public string OtrosDescripcionFarmaceuticos { get; set; }
    }
}
