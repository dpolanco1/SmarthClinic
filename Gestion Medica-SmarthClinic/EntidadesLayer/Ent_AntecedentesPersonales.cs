using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesLayer
{
  public  class Ent_AntecedentesPersonales
    {
        public int IDAntecedentePersonales { get; set; }
        public int IDHistorial { get; set; }
        public bool   InfartoMiocardioPrevio  { get; set; }
        public bool  InsuficienciaCardiaca  { get; set; }
        public bool  HipertensionArterial  { get; set; }
        public bool   Valvulopatia  { get; set; }
        public bool   Arritmia  { get; set; }
        public bool    DiabetisMellitas  { get; set; }
        public bool    EnfermedadRenal  { get; set; }
        public bool    EnfermedadHepatica  { get; set; }
        public bool    EnfermedadPulmonar  { get; set; }
        public bool    Tiroides  { get; set; }
        public bool    ACV  { get; set; }
        public bool    ASMA  { get; set; }
        public bool    Gastritis  { get; set; }
        public bool    UlceraPeptica  { get; set; }
        public bool     Amigdalitis  { get; set; }
        public bool     DoloresCronicosCabeza  { get; set; }
        public bool    EnfermedadesRinon  { get; set; }
        public bool   Convulsiones { get; set; }
        public bool   SentidoDevilOlfato { get; set; }
        public bool   Obesidad { get; set; }
        public bool    EnfermedadesHigado { get; set; }
        public bool   EnfermedadesTransmisionSexual { get; set; }
        public bool     Cancer { get; set; }
        public bool    Alergias { get; set; }
        public string OtrosDescripcionPersonales { get; set; }

    }
}
