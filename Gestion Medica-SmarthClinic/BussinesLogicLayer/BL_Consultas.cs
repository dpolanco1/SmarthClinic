using DataAccessLayer;
using EntidadesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BussinesLogicLayer
{
   public class BL_Consultas
    {
        private static Da_Consultas GetDaConsulta()//metodo singleton
        {
            Da_Consultas daConsulta = new Da_Consultas();
            return daConsulta;
        }


        public static bool Insert(Ent_Consultas entConsulta)
        {
            //instancio el metodo
            Da_Consultas daConsulta = GetDaConsulta();
            
            //Validaciones De Lugar
            bool flag = false;
            try
            {
                if (String.IsNullOrEmpty(entConsulta.Motivo) || String.IsNullOrEmpty(entConsulta.Diagnostico))
                {

                    flag = false;

                }
                else if (Da_Consultas.InsertaConsulta(entConsulta))
                {

                    flag = true;

                }
            }
            catch (Exception err) { throw new Exception(err.Message); }
            return flag;
        }
        public static bool VerificarConexion()
        {
            bool flag = false;

            if (Da_Paciente.VerificarConecxion())
            {
                flag = true;
            }
            else { flag = false; }

            return flag;
        }

        public static DataTable GetAllMedicos()
        {
            return Da_Consultas.GetAllMedicos();
        }
        public static DataTable GetAllPacientes()
        {
            return Da_Consultas.GetAllPacientes();
        }
    }
}
