using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class Da_AntecedentesFamiliares
    {
        public static bool Insert(Ent_AntecedentesFamiliares entFamiliares)
        {
            bool flag = false;

            try
            {
                SqlCommand command = new SqlCommand("Spr_Insert_AntecedentesFarmiliares", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Da_Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@IDHistorial", entFamiliares.IDHistorial) { SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter("@Padre", entFamiliares.AntecedentesPadre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Madre", entFamiliares.AntecedentesMadre) { SqlDbType = SqlDbType.NVarChar});
                command.Parameters.Add(new SqlParameter("@Hermanos", entFamiliares.AntecedentesHermanos) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descripcion", entFamiliares.OtrosDescripcionFamiliares) { SqlDbType = SqlDbType.NVarChar });
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            } // end catch

            finally
            {

                if (Da_Connection.Get.State != ConnectionState.Closed)
                {
                    Da_Connection.Get.Close();
                }
            }

            return flag;
        }




        public static bool Update()
        {
            bool flag = false;


            return flag;
        }
    }
}
