using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    public class Bl_AntecedentesFamiliares
    {

        public static bool Insert(Ent_AntecedentesFamiliares entAntecedentesFamiliares)
        {

            return Da_AntecedentesFamiliares.Insert(entAntecedentesFamiliares);

        }

    }
}
