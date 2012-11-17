using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public   class Da_HistorialClinico
    {
        
        public static bool Insert(Ent_HistorialClinico entHistorialClinico)
        {
            bool flag = false;


            try
             
            {

                //conecction = new DAConecction();
                SqlCommand command = new SqlCommand("Spr_InsertHistorialClinico", Da_Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                //Abro la conecxion
                Da_Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@IDPaciente", entHistorialClinico.IDPaciente) { SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter("@RemitidoPor", entHistorialClinico.RemitidoPor) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Sintomas", entHistorialClinico.SintomasEvoluciones) { SqlDbType = SqlDbType.NVarChar });
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

