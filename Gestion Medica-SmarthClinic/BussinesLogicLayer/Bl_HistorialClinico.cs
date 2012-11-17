using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using DataAccessLayer;


namespace BussinesLogicLayer
{
   public class Bl_HistorialClinico
    {

     
        public static bool Insert(Ent_HistorialClinico entHistorialClinico)
        {

            return Da_HistorialClinico.Insert(entHistorialClinico);
            
        }
        public bool Update()
        {

            bool flag = false;

            return flag;

        }
        public bool Delete()
        {
            bool flag = false;

            return flag;

        }
        public bool Search()
        {
            bool flag = false;

            return flag;

        }


    }
}
