using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using DataAccessLayer;

namespace BussinesLogicLayer
{
 public   class Bl_AntecedentesToxicos
    {

     public static bool Insert(Ent_AntecedentesToxicos entAntecedentesToxicos)
     {

         return Da_AntecedentesToxicos.Insert(entAntecedentesToxicos);
     }

    }
}
