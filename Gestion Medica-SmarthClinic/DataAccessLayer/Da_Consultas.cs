using EntidadesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Da_Consultas
    {
        public static bool InsertaConsulta(Ent_Consultas EntidadConsulta)
        {
            bool flag = false;

            try
            {

                //Utilizo la clase Command Insertar en un StroreProcedure
                using (SqlCommand command = new SqlCommand("sp_insertarconsulta", Da_Connection.Get) { CommandType = CommandType.StoredProcedure })
                {
                    Da_Connection.Get.Open();
                    command.Parameters.AddWithValue("@idmedico", EntidadConsulta.IDMedico);
                    command.Parameters.AddWithValue("@idpaciente", EntidadConsulta.IDPaciente);
                    command.Parameters.AddWithValue("@motivo", EntidadConsulta.Motivo);
                    command.Parameters.AddWithValue("@diagnostico", EntidadConsulta.Diagnostico);
                    command.Parameters.AddWithValue("@fechaconsulta", Ent_Consultas.Fecha);
                    int succed = Convert.ToInt16(command.ExecuteNonQuery());
                    if (succed > 0)
                        flag = true;
                    else
                        flag = false;
                }

            }
            catch (Exception err) { Console.WriteLine(err.Message); }
            finally
            {

                if (Da_Connection.Get.State != ConnectionState.Closed)
                {
                    Da_Connection.Get.Close();
                }

            }
            return flag;
        }

        public static DataTable GetAllMedicos()
        {
            DataTable dt = new DataTable();

            try
            {

                Da_Connection.Get.Open();
                using (SqlDataAdapter da = new SqlDataAdapter() { SelectCommand = new SqlCommand("sp_selectmedicos", Da_Connection.Get) })
                {
                    da.Fill(dt);
                }

                return dt;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            finally
            {

                if (Da_Connection.Get.State != ConnectionState.Closed)
                {
                    Da_Connection.Get.Close();
                }

            }//fin del Finally

            return dt;
        }
        public static DataTable GetAllPacientes()
        {
            DataTable dt = new DataTable();

            try
            {

                Da_Connection.Get.Open();
                using (SqlDataAdapter da = new SqlDataAdapter() { SelectCommand = new SqlCommand("sp_selectpaciente", Da_Connection.Get) })
                {
                    da.Fill(dt);
                }

                return dt;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            finally
            {

                if (Da_Connection.Get.State != ConnectionState.Closed)
                {
                    Da_Connection.Get.Close();
                }

            }//fin del Finally

            return dt;
        }
    }
}