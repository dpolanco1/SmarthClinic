using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesLayer
{
    public class Ent_AntecedentesToxicos
    {
        public int IDAntecedenteToxico { get; set; }
        public int IDHistorial { get; set; }
        public bool Tabasco { get; set; }
        public bool Alcohol { get; set; }
        public bool Cafe { get; set; }
        public bool Te { get; set; }
        public bool Drogas { get; set; }
        public string OtrosDescripcionToxico { get; set; }


    }
}
