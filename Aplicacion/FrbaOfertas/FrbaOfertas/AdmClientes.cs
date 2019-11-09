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
    public static class AdmClientes
    {
        public static DataSet obtenerClientes() {

            DataTable dtClientes = new DataTable();
            // string connString = @"Server =.\SQLSERVER2012; Database = GD2C2019;user id=gdCupon2019;pwd=gd2019";
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {

                //define the query text
                string query = "SELECT TOP 1000 [Cli_Dni],[Cli_Nombre],[Cli_Apellido],[Cli_Mail],[Cli_Direccion],[Cli_Ciudad],[Cli_Fecha_Nac],[Cli_Telefono] FROM [GD2C2019].[THE_RIGHT_JOIN].[Cliente]";

                //define the SqlCommand object
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //open connection
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    //dtClientes.Load(reader);
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtClientes);
                    ds.Load(reader, LoadOption.PreserveChanges, ds.Tables[0]);
                    //close connection
                    conn.Close();
                    return ds;
                }
                
                
            } 
        }
    }
}
