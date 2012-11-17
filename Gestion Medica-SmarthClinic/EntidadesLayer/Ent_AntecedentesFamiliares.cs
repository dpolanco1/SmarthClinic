using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesLayer
{
    public class Ent_AntecedentesFamiliares
    {
        public int IDAntecedenteFamiliares { get; set; }
        public int IDHistorial { get; set; }
        public string AntecedentesPadre { get; set; }
        public string AntecedentesMadre { get; set; }
        public string AntecedentesHermanos { get; set; }
        public string OtrosDescripcionFamiliares { get; set; }
    }
}
