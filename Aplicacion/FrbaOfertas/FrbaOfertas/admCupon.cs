using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrbaOfertas
{
    class admCupon
    {
        public static int consumirOferta(int dni, DateTime fechaActual, int codigoOferta)
        {

            int filas;

            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.consumirOferta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dniCli", SqlDbType.Decimal).Value = Convert.ToDecimal(dni);
                    cmd.Parameters.Add("@codCupon", SqlDbType.Decimal).Value = Convert.ToDecimal(codigoOferta);
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fechaActual;
                    cmd.Parameters.Add("@filasAfectadas", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    filas = Convert.ToInt32(cmd.Parameters["@filasAfectadas"].Value);
                    conn.Close();
                }
            }

            return filas;

        }

        public static DataSet obtenerCuponesXCliente(int dni) {

            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "select * from THE_RIGHT_JOIN.obtenerCuponesPorCliente(@dni)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = Convert.ToDecimal(dni);
            return ConectorBDD.cargarDataSet(conn, cmd);
        
        }

        public static DataSet obtenerCuponesXClienteYProv(int dni, String cuit)
        {

            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "select * from THE_RIGHT_JOIN.obtenerCuponesPorClienteYProv(@dni,@cuit)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = Convert.ToDecimal(dni);
            cmd.Parameters.Add("@cuit", SqlDbType.NVarChar).Value = cuit;
            return ConectorBDD.cargarDataSet(conn, cmd);

        }
    }
}
