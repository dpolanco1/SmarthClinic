using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class Da_Telefono
    {
       
        public static bool Insert(Ent_Telefono EntidadTelefono)
        {
            bool flag = false;
               
            try

            {

                //conecction = new DAConecction();
                SqlCommand command = new SqlCommand("Spr_InsertTelefonos", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                //Abro la conecxion
                Da_Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Telefono", EntidadTelefono.Telefono) { SqlDbType = SqlDbType.NVarChar });
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
        }//fin del Metodo Insert
        public static bool Update(Ent_Telefono EntidadTelefono)
        {

            bool flag = false;

            try
            {

                //conecction = new DAConecction();
                SqlCommand command = new SqlCommand("Spr_UpdateTelefonos", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                //Abro la conecxion
                Da_Connection.Get.Open();
                
                command.Parameters.Add(new SqlParameter("@IDPaciente", EntidadTelefono.IDPaciente) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", EntidadTelefono.Telefono) { SqlDbType = SqlDbType.NVarChar });
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
        public static bool Delete(int IDPaciente)
        {
            bool flag = false;

            try
            {

                //conecction = new DAConecction();
                SqlCommand command = new SqlCommand("Spr_DeleteTelefonos", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                //Abro la conecxion
                Da_Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@IDPaciente", IDPaciente) { SqlDbType = SqlDbType.NVarChar });
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
        public static DataTable SearchTelefonosporIDPaciente(int idPaciente)
        {
            DataTable sqlTbl = new DataTable();

            try
            {

                Da_Connection.Get.Open();

                SqlCommand command = new SqlCommand("Spr_SearchTelefonosIDPaciente", Da_Connection.Get);
                command.Connection = Da_Connection.Get;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDPaciente", idPaciente);
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(sqlTbl);


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

            return sqlTbl;//ayudame ahi
        }

    }
}
