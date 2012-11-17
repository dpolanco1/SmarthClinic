using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class Da_Connection
    {

        private Da_Connection() { }

                //Metodo Singlenton
                private static SqlConnection _connection = null;

                public static SqlConnection Get
                {
                    get
                    {
                        try
                        {

                      
                        if (_connection == null)
                            _connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["aPresentationLayer.Properties.Settings.SmartHearthCareDbConnectionStringOneximo"].ToString());
                           // _connection = new SqlConnection(@"workstation id=SmartHearthCareDb.mssql.somee.com;packet size=4096;user id=AppCodee;pwd=AppCodee123;data source=SmartHearthCareDb.mssql.somee.com;persist security info=False;initial catalog=SmartHearthCareDb");
                            //_connection = new SqlConnection(@"Data Source=(local);Initial Catalog=Prueba;Integrated Security=True");
                        return _connection;
                        }
                        catch (Exception)
                        {

                            
                        }
                        return _connection;
                    }
                }
        /*
   static Da_Connection Instance = null;
   static SqlConnection _conn = null;

   private Da_Connection() { }
        
        
   private static void CreateInstance()
   {   
       if(Instance == null)
       { 
           Instance = new Da_Connection();
            
       }
        
   }
public static Da_Connection GetInstance(string conStr)
{    
   if(Instance == null)
        
   {
       CreateInstance();
            
       Instance.ConnectionString = conStr;
       Instance.Get();
        
   }
   return Instance;
}
   void Get()
   {
       try{
                
           _conn = new SqlConnection();
           _conn.StateChange += delegate(object o, StateChangeEventArgs args)
           {
                    
               Info = String.Format(" {1}| {2}| {3}|",args.CurrentState.ToString(),
                System.DateTime.Now.ToLocalTime(),_conn.DataSource,_conn.Database);
           };
                
           _conn.ConnectionString = ConnectionString;
           _conn.Open();
           IsOpen = true;
       }
       catch(SqlException x)
            
       {
           if (_conn.State == System.Data.ConnectionState.Open)
                    
               _conn.Close();
                
           throw x;
       }
        
   }
        
   public void Close()
   {
            
      if (_conn.State == System.Data.ConnectionState.Open){
         _conn.Close();
         IsOpen = false;
           
      }
        
   }
        
   string ConnectionString {set;get;}
   public bool IsOpen {set;get;}
   public string Info {set;get;} 
}
}*/

    }

}
