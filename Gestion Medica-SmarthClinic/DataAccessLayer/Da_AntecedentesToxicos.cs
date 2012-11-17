using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesLayer;

namespace DataAccessLayer
{
    public class Da_AntecedentesToxicos
    {

        public static bool Insert(Ent_AntecedentesToxicos entHabitos)
        {
            bool flag = false;

            try
            {
                SqlCommand command = new SqlCommand("Spr_Insert_AntecedentesToxicos", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Da_Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@IDHistorial", entHabitos.IDHistorial) { SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter("@Tabaco", entHabitos.Tabasco) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@Alcohol", entHabitos.Alcohol) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@Cafe", entHabitos.Cafe) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@Te", entHabitos.Te) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@Drogas", entHabitos.Drogas) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@Descripcion", entHabitos.OtrosDescripcionToxico) { SqlDbType = SqlDbType.NVarChar});
               

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
