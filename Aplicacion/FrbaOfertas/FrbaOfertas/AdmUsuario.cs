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
    class AdmUsuario
    {
        public static int altaUsuario(Usuario user, int idRol)
        {
            int retorno;

            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.altaUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = user.User;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = user.Password;
                    if (user.DNI != 0){
                        cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = user.DNI;
                    }
                    else {
                        cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = null;
                    }
                    cmd.Parameters.Add("@cuit", SqlDbType.VarChar).Value = user.CUIT;
                    cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
                    cmd.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output;
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    retorno = Convert.ToInt32(cmd.Parameters["@retorno"].Value);
                    conn.Close();
                }
            }

            return retorno;
        }

        public static List<String> funcionalidadesDelRol(Decimal idRol)
        { 
            //ahora esta hardcodeadisimo, despues hay que obtenga las funcionalidades del cliente de la BDD
            List<String> funcionalidades = new List<String>();
            
            return funcionalidades;
        }

        public static int logueo(String username, String password)
        {

            int ret;
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.logueo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;

                    cmd.Parameters.Add("@ret", SqlDbType.Int).Direction = ParameterDirection.Output;;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    
                    ret = Convert.ToInt32(cmd.Parameters["@ret"].Value);

                    conn.Close();
                }
            }

            return ret;
        }

        public static void cambiarContrasenia(String usuario, String contraNueva){
        
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.cambiarContra", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = contraNueva;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static DataSet obtenerUsuarios() {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "SELECT Usuari_idUser, Usuari_Username FROM THE_RIGHT_JOIN.Usuario WHERE Usuari_Habilitado = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            return ConectorBDD.cargarDataSet(conn, cmd);
        }

        public static void eliminarUsuario(String username) {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.eliminarUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        
    }
}
