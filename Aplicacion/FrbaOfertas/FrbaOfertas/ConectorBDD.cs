using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace FrbaOfertas
{
    public static class ConectorBDD
    {
        public static DataSet cargarDataSet(SqlConnection conn,SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            //string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            using (conn)
            {
                using (cmd)
                {
                    //open connection
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    //dtClientes.Load(reader);
                    ds.Tables.Add(dt);
                    ds.Load(reader, LoadOption.PreserveChanges, ds.Tables[0]);
                    //close connection
                    conn.Close();
                    return ds;
                }
            }
        }
    }
}
