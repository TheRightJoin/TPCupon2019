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
         

        public static DataSet obtenerClientes()
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString); 
            String query = "SELECT TOP 1000 [Cli_Dni],[Cli_Nombre],[Cli_Apellido],[Cli_Mail],[Cli_Direccion],[Cli_Ciudad],[Cli_Fecha_Nac],[Cli_Telefono] FROM [GD2C2019].[THE_RIGHT_JOIN].[Cliente]";
            query += "WHERE Cli_Activo IS NULL OR Cli_Activo = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            return ConectorBDD.cargarDataSet(conn,cmd);

        }

        public static Cliente obtenerCliente(Decimal dniCliente)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "select * from THE_RIGHT_JOIN.obtenerClienteDNI(@dni)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = dniCliente;
            DataSet ds = ConectorBDD.cargarDataSet(conn, cmd);
            String nombre = ds.Tables[0].Rows[0]["Cli_Nombre"].ToString();
            String apellido = ds.Tables[0].Rows[0]["Cli_Apellido"].ToString();
            String mail = ds.Tables[0].Rows[0]["Cli_Mail"].ToString();
            String direccion = ds.Tables[0].Rows[0]["Cli_Direccion"].ToString();
            String ciudad = ds.Tables[0].Rows[0]["Cli_Ciudad"].ToString();
            DateTime fechaNac = Convert.ToDateTime(ds.Tables[0].Rows[0]["Cli_Fecha_Nac"]);
            Decimal telefono = Convert.ToDecimal(ds.Tables[0].Rows[0]["Cli_Telefono"]);
            String codPostal = ds.Tables[0].Rows[0]["Cli_CodPostal"].ToString();
            String localidad = ds.Tables[0].Rows[0]["Cli_Localidad"].ToString();
            Cliente cli = new Cliente(dniCliente, nombre, apellido, mail, direccion, ciudad, fechaNac, telefono, codPostal,localidad);
            return cli;
        }


        public static void altaCliente(Cliente cli)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString); 
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.altaCliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = cli.dni;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cli.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cli.apellido;
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = cli.mail;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cli.direccion;
                    cmd.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = cli.ciudad;
                    cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = cli.fechaNac;
                    cmd.Parameters.Add("@telefono", SqlDbType.Decimal).Value = cli.telefono;
                    cmd.Parameters.Add("@codpost", SqlDbType.VarChar).Value = cli.codPostal;
                    cmd.Parameters.Add("@localidad", SqlDbType.VarChar).Value = cli.localidad;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static void modificarCliente(Cliente cli)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.modificarCliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = cli.dni;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cli.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cli.apellido;
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = cli.mail;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cli.direccion;
                    cmd.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = cli.ciudad;
                    cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = cli.fechaNac;
                    cmd.Parameters.Add("@telefono", SqlDbType.Decimal).Value = cli.telefono;
                    cmd.Parameters.Add("@codpost", SqlDbType.VarChar).Value = cli.codPostal;
                    cmd.Parameters.Add("@localidad", SqlDbType.VarChar).Value = cli.localidad;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static void bajaCliente(Decimal dni)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.bajaCliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = dni;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static DataSet generarQuerys(String dni, String nombre, String apellido, String mail)
        {           
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "SELECT [Cli_Dni],[Cli_Nombre],[Cli_Apellido],[Cli_Mail],[Cli_Direccion],[Cli_Ciudad],[Cli_Fecha_Nac],[Cli_Telefono],[Cli_CodPostal],[Cli_Localidad]";
            query += " FROM [GD2C2019].[THE_RIGHT_JOIN].[Cliente]";
            query += " WHERE (Cli_Activo IS NULL OR Cli_Activo = 1)";
            query += " AND Cli_Apellido LIKE '%' + @apellido + '%'";
            query += " AND Cli_Mail LIKE '%' + @mail + '%'";
            query += " AND Cli_Nombre LIKE '%' + @nombre + '%'";
            if (dni == "")
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramNombre = cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                paramNombre.Value = nombre;
                SqlParameter paramApellido = cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
                paramApellido.Value = apellido;
                SqlParameter paramMail = cmd.Parameters.Add("@mail", SqlDbType.VarChar);
                paramMail.Value = mail;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }
            else {
                query += " AND Cli_Dni = @dni";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramNombre = cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                paramNombre.Value = nombre;
                SqlParameter paramApellido = cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
                paramApellido.Value = apellido;
                SqlParameter paramMail = cmd.Parameters.Add("@mail", SqlDbType.VarChar);
                paramMail.Value = mail;
                SqlParameter paramDni = cmd.Parameters.Add("@dni", SqlDbType.Decimal);
                paramDni.Value = Convert.ToDecimal(dni);
                return ConectorBDD.cargarDataSet(conn, cmd);
            }            
            
           
        }
    }
}
