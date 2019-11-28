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
        public static DataSet obtenerRoles(String nombre)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "SELECT [id_Rol],[rol_Name],[rol_habilitado] FROM [GD2C2019].[THE_RIGHT_JOIN].[Rol] WHERE rol_name LIKE '%' + @nombre + '%' AND rol_habilitado = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter paramNombre = cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
            paramNombre.Value = nombre;
            return ConectorBDD.cargarDataSet(conn, cmd);
        }

        public static DataSet cargarComboBoxRoles() {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "SELECT [id_Rol],[rol_Name],[rol_habilitado] FROM [GD2C2019].[THE_RIGHT_JOIN].[Rol] WHERE [rol_Name] <> 'ADMIN'";
            SqlCommand cmd = new SqlCommand(query, conn);
            return ConectorBDD.cargarDataSet(conn, cmd);
        }

        public static void bajaRol(int idRol)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.bajaRol", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static int altaRol(String nombre)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            int filas;
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.crearRol", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                    cmd.Parameters.Add("@filasAfectadas", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    filas = Convert.ToInt32(cmd.Parameters["@filasAfectadas"].Value);
                    conn.Close();
                }
            }
            return filas;
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

            public static DataSet obtenerFuncionalidadesRol(int idRol)
            {
                string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                String query = "SELECT * FROM [GD2C2019].[THE_RIGHT_JOIN].[traerFuncDelRol](@rol)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@rol", SqlDbType.Int).Value = idRol;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }
        }

}
