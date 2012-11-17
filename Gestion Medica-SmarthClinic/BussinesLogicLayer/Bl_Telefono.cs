using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using DataAccessLayer;
using System.Data;

namespace BussinesLogicLayer
{
    public class Bl_Telefono
    {

        private static Da_Telefono GetDaTelefono()//metodo singleton
        {
            Da_Telefono daTelefono = new Da_Telefono();
            return daTelefono;
        }

        public static bool Insert(Ent_Telefono entTelefono)
        {
            //instancio el metodo
            Da_Telefono daTelefono = GetDaTelefono();

            //Validaciones De Lugar
            bool flag = false;

            if (string.IsNullOrEmpty(entTelefono.Telefono) )

            {
             flag= false;
            
            }   else if (Da_Telefono.Insert(entTelefono))            
            {
                 
                 flag= true;
            }        

            return flag;


        }

        public static bool Update(Ent_Telefono entTelefono)
        {

            //instancio el metodo
            Da_Telefono daTelefono = GetDaTelefono();

            //Validaciones De Lugar
            bool flag = false;

            if (entTelefono.IDPaciente.Equals(String.Empty) || entTelefono.Telefono.Equals(String.Empty))
            {
                flag = false;

            }
            else if (Da_Telefono.Update(entTelefono))
            {

                flag = true;
            }

            return flag;



        }

        public static bool Delete(int IDPaciente)
        {
            //instancio el metodo
            Da_Telefono daTelefono = GetDaTelefono();

            //Validaciones De Lugar
            bool flag = false;

            if (IDPaciente < 1)
            {
                flag = false;

            }
            else if (Da_Telefono.Delete(IDPaciente))
            {

                flag = true;
            }

            return flag;


        }

        public static DataTable SearchTelefonosporIDPaciente(int IDPaciente)
        {
            // Da_Direcciones dd = new Da_Direcciones();
            return Da_Telefono.SearchTelefonosporIDPaciente(IDPaciente);
        }
    }
}
