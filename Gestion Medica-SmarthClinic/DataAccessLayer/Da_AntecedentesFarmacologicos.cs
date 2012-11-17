using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessLayer
{
    public class Da_AntecedentesFarmacologicos
    {
        public static bool Insert(Ent_AntecedentesFarmacologicos entFamacologicos)
        {
            bool flag = false;

            try
            {
                SqlCommand command = new SqlCommand("Spr_Insert_AntecedentesFarmacologicos", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Da_Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@IDHistorial", entFamacologicos.IDHistorial) { SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter("@AntiHipertensivos", entFamacologicos.AntiHipertensivos) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@AntiPlaquetarios", entFamacologicos.AntiPlaquetarios) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@AntiCoagulante", entFamacologicos.AntiCoagulante) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@AntiArritmico", entFamacologicos.AntiArritmico) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@Antibioticos", entFamacologicos.Antibioticos) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@AntiIflamatorios", entFamacologicos.Antiflamatorios) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@Esteroides", entFamacologicos.Esteroides) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Descripcion", entFamacologicos.OtrosDescripcionFarmaceuticos) { SqlDbType = SqlDbType.NVarChar });


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
