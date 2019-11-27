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
    public class AdmRol
    {
        public static DataSet obtenerRoles()
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "SELECT [id_Rol],[rol_Name],[rol_habilitado] FROM [GD2C2019].[THE_RIGHT_JOIN].[Rol]";
            SqlCommand cmd = new SqlCommand(query, conn);
            return ConectorBDD.cargarDataSet(conn, cmd);
        }

        public static DataSet obtenerRolesPorUsuario(string username)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "SELECT * FROM [GD2C2019].[THE_RIGHT_JOIN].[traerRolxUsuario](@username)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            return ConectorBDD.cargarDataSet(conn, cmd);
        }
    }
}
