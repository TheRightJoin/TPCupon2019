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
    public static class AdmOfertas
    {
        public static int altaOferta(Oferta of)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            int filas;
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.altaOferta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = of.codigo;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = of.precio;
                    cmd.Parameters.Add("@precioFicticio", SqlDbType.Decimal).Value = of.precioFicticio;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = of.fechaPub;
                    cmd.Parameters.Add("@fecha_ven", SqlDbType.DateTime).Value = of.fechaVen;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = of.cant;
                    cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = of.descripcion;
                    cmd.Parameters.Add("@disponible", SqlDbType.Decimal).Value = of.disponible;
                    cmd.Parameters.Add("@cuit", SqlDbType.VarChar).Value = of.cuit;
                    cmd.Parameters.Add("@cantxClie", SqlDbType.Decimal).Value = of.cantxCli;
                    cmd.Parameters.Add("@filasAfectadas", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    filas = Convert.ToInt32(cmd.Parameters["@filasAfectadas"].Value);
                    conn.Close();
                }
            }
            return filas;
        }

        public static DataSet obtenerOfertasDisponibles()
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "select * from THE_RIGHT_JOIN.traerOfertasDisponibles(@fecha)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);
            return ConectorBDD.cargarDataSet(conn, cmd);

        }

        public static DataSet obtenerOfertasPorCliente(String cuit, DateTime fechamin, DateTime fechamax, DateTime fechaActual)
        {

            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "select * from THE_RIGHT_JOIN.ofertasAdquiridasPorCliente(@cuit, @fechaMin, @fechaMax, @fechaAct)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@cuit", SqlDbType.VarChar).Value = cuit;
            cmd.Parameters.Add("@fechaMin", SqlDbType.Date).Value = fechamin;
            cmd.Parameters.Add("@fechaMax", SqlDbType.Date).Value = fechamax;
            cmd.Parameters.Add("@fechaAct", SqlDbType.Date).Value = fechaActual;
            return ConectorBDD.cargarDataSet(conn, cmd);
        }
        public static int comprarOferta(Decimal dni, DateTime fecha, int cantidad, String codigoOferta)
        {

            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            int resultado;
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.comprarOferta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = dni;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = Convert.ToDecimal(cantidad);
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                    cmd.Parameters.Add("@codOferta", SqlDbType.VarChar).Value = codigoOferta;
                    cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToInt32(cmd.Parameters["@resultado"].Value);
                    conn.Close();
                }
            }

            return resultado;
        }



    }
}
