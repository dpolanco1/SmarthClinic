using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesLayer
{
    public class Ent_Paciente
    {
          //
         public string IDPaciente {get;set;}
		 public  string Nombres {get;set;}
		 public  string Apellidos {get;set;}
		 public  int IDTipoIdentifacion {get;set;}
		 public  string Identificacion {get;set;}
         public string Genero { get; set; }
         public int TipoPaciente { get; set; }
         public string EstadoCivil { get; set; }
         public string TipoSangre { get; set; }
         public decimal Peso { get; set; }
         public decimal Altura { get; set; }
         public  string Edad {get;set;}
         public string Email { get; set; }
         public string Direccion { get; set; }



    }
}
