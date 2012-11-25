using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using DataAccessLayer;
using System.Data;
using System.Windows.Forms;


namespace BussinesLogicLayer
{
    public class Bl_Paciente
    {

        private static Da_Paciente GetDaPaciente()//metodo singleto
        {
            Da_Paciente daPaciente = new Da_Paciente();
            return daPaciente;
        }


        public static bool Insert(Ent_Paciente entPaciente)
        {
            //instancio el metodo
            Da_Paciente daPaciente = GetDaPaciente();

            //Validaciones De Lugar
            bool flag = false;

            if (String.IsNullOrEmpty(entPaciente.Nombres) || String.IsNullOrEmpty(entPaciente.Apellidos))

            { 
            
               flag = false;
            
            }else if ( Da_Paciente.Insert(entPaciente))
            
            {

                flag = true;

            }

            return flag;
        }

        public static bool Update(Ent_Paciente entPaciente)
        {

            //instancio el metodo
            Da_Paciente daPaciente = GetDaPaciente();

            //Validaciones De Lugar
            bool flag = false;

            if (String.IsNullOrEmpty(entPaciente.Nombres) || String.IsNullOrEmpty(entPaciente.Apellidos))
            {

                flag = false;

            }
            else if (Da_Paciente.Update(entPaciente))
            {

                flag = true;

            }

            return flag;


        }

        public static bool Delete(int IDPaciente)
        {
            //instancio el metodo
            Da_Paciente daPaciente = GetDaPaciente();

            //Validaciones De Lugar
            bool flag = false;

            if (IDPaciente < 1)
            {

                flag = false;

            }
            else if (Da_Paciente.Delete(IDPaciente))
            {

                flag = true;

            }

            return flag;

        }
        public static DataTable SearchAll()
        {
            return Da_Paciente.SearchAll();
        }
        public static int SearchIDPaciente()
        {
            return Da_Paciente.SearchIDPaciente();
        }

        public static bool VerificarConecxion()
        {
            bool flag = false;

            if (Da_Paciente.VerificarConecxion())
            {
                flag = true;
            }
            else { flag = false; }

            return flag;
        }
    }

}
