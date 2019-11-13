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
                    cmd.Parameters.Add("@filasAfectadas", SqlDbType.Int).Direction = ParameterDirection.Output;                  
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    filas = Convert.ToInt32(cmd.Parameters["@filasAfectadas"].Value);
                    conn.Close();
                }
            }
            return filas;
        }
    }
}
