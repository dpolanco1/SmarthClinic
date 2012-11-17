using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using DataAccessLayer;
using System.Data;

namespace BussinesLogicLayer
{
    public class Bl_Direcciones
    {
        private static Da_Direcciones GetDaDirecciones()//metodo singleton
        {
            Da_Direcciones daDirecciones = new Da_Direcciones();
            return daDirecciones;
        }



        public static bool Insert(Ent_Direcciones entDirecciones)
        {

            //instancio el metodo
            Da_Direcciones daDirecciones = GetDaDirecciones();

            //Validaciones De Lugar
            bool flag = false;

            if (String.IsNullOrEmpty(entDirecciones.Direccion))

            {
             flag= false;
            
            }   else if (Da_Direcciones.Insert(entDirecciones))            
            {
                 
                 flag= true;
            }        

            return flag;


        }

        public static bool Update(Ent_Direcciones entDirecciones)
        {

            //instancio el metodo
            Da_Direcciones daDirecciones = GetDaDirecciones();

            //Validaciones De Lugar
            bool flag = false;

            if (entDirecciones.IDPaciente.Equals(String.Empty) || entDirecciones.Direccion.Equals(String.Empty))
            {
                flag = false;

            }
            else if (Da_Direcciones.Update(entDirecciones))
            {

                flag = true;
            }

            return flag;

        }

        public static bool Delete(int IDPaciente)
        {
            //instancio el metodo
            Da_Direcciones daDirecciones = GetDaDirecciones();

            //Validaciones De Lugar
            bool flag = false;

            if (IDPaciente < 1)
            {
                flag = false;

            }
            else if (Da_Direcciones.Delete(IDPaciente))
            {

                flag = true;
            }

            return flag;


        }

        public static  DataTable SearchDireccionesporIDPaciente(int IDPaciente)
        {
           // Da_Direcciones dd = new Da_Direcciones();
            return Da_Direcciones.SearchDireccionesporIDPaciente(IDPaciente);
        }
    }
}
