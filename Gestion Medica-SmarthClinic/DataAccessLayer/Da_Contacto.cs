using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using System.Data.SqlClient;
using System.Data;
namespace DataAccessLayer
{
    public class Da_Contacto
    {

        public static bool Insert(Ent_Contacto EntidadContacto)
        {
            bool flag = false;


            try
             
            {

                //conecction = new DAConecction();
                SqlCommand command = new SqlCommand("Spr_InsertContactos", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                //Abro la conecxion
                Da_Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Contacto", EntidadContacto.Contacto) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", EntidadContacto.Telefono) { SqlDbType = SqlDbType.NVarChar });
                
                //Realizo el Query
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
        public static bool Update(Ent_Contacto EntidadContacto)
        {
            bool flag = false;


            try
            {

                //conecction = new DAConecction();
                SqlCommand command = new SqlCommand("Spr_UpdateContactos", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                //Abro la conecxion
                Da_Connection.Get.Open();
                command.Parameters.Add(new SqlParameter("@IDPaciente", EntidadContacto.IDPaciente) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Contacto", EntidadContacto.IDContacto) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", EntidadContacto.Telefono) { SqlDbType = SqlDbType.NVarChar });

                //Realizo el Query
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
                SqlCommand command = new SqlCommand("Spr_DeleteContactos", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                //Abro la conecxion
                Da_Connection.Get.Open();

             
                command.Parameters.Add(new SqlParameter("@IDPaciente", IDPaciente) { SqlDbType = SqlDbType.NVarChar });


                //Realizo el Query
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
        public static DataTable SearchContactosporIDPaciente(int idPaciente)
        {
            DataTable sqlTbl = new DataTable();

            try
            {

                Da_Connection.Get.Open();

                SqlCommand command = new SqlCommand("Spr_SearchContactosIDPaciente", Da_Connection.Get);
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
