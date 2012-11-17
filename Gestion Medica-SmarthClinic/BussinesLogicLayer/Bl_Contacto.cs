using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using DataAccessLayer;
using System.Data;

namespace BussinesLogicLayer
{
    public class Bl_Contacto
    {

        private static Da_Contacto GetDaContacto()//metodo singleton
        {
            Da_Contacto daContacto = new Da_Contacto();
            return daContacto;
        }


        public static bool Insert(Ent_Contacto entContacto)
        {
            //instancio el metodo
            Da_Contacto daContacto = GetDaContacto();

             //Validaciones De Lugar
            bool flag = false;


            if (string.IsNullOrEmpty(entContacto.Contacto) ||string.IsNullOrEmpty(entContacto.Telefono))

            {
                flag = false;

            }
            else if (Da_Contacto.Insert(entContacto)) 
            {
                flag = true;
            
            }


            return flag;

        }

        public static bool Update(Ent_Contacto entContacto)
        {

            //instancio el metodo
            Da_Contacto daContacto = GetDaContacto();

            //Validaciones De Lugar
            bool flag = false;


            if (entContacto.IDPaciente.Equals(String.Empty) || entContacto.IDContacto.Equals(String.Empty) || entContacto.Telefono.Equals(String.Empty))
            {
                flag = false;

            }
            else if (Da_Contacto.Update(entContacto))
            {
                flag = true;

            }


            return flag;





        }

        public static bool Delete(int IDPaciente)
        {
            //instancio el metodo
            Da_Contacto daContacto = GetDaContacto();

            //Validaciones De Lugar
            bool flag = false;


            if (IDPaciente < 1)
            {
                flag = false;

            }
            else if (Da_Contacto.Delete(IDPaciente))
            {
                flag = true;

            }


            return flag;



        }

        public static DataTable SearchContactosporIDPaciente(int IDPaciente)
        {
            // Da_Direcciones dd = new Da_Direcciones();
            return Da_Contacto.SearchContactosporIDPaciente(IDPaciente);
        }
    }
}
