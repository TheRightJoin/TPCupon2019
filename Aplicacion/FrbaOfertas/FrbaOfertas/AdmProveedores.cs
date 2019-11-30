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
    public class AdmProveedores
    {
        public static int AltaProveedor(Proveedor miProveedor)
        {
            int resultado;
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.altaProveedor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@razonSocial", SqlDbType.VarChar).Value = miProveedor.razon_social;
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = miProveedor.direccion;
                    cmd.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = miProveedor.ciudad;
                    cmd.Parameters.Add("@telefono", SqlDbType.Decimal).Value = miProveedor.telefono;
                    cmd.Parameters.Add("@cuit", SqlDbType.VarChar).Value = miProveedor.CUIT;
                    cmd.Parameters.Add("@idRubro", SqlDbType.Int).Value = miProveedor.idRubro;
                    cmd.Parameters.Add("@activo", SqlDbType.Decimal).Value = 1;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = miProveedor.email;
                    cmd.Parameters.Add("@postal", SqlDbType.VarChar).Value = miProveedor.postal;
                    cmd.Parameters.Add("@contacto", SqlDbType.VarChar).Value = miProveedor.contacto;
                    cmd.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToInt32(cmd.Parameters["@retorno"].Value);
                    conn.Close();
                }
            }

            return resultado;
        }

        public static Proveedor obtenerProveedor(String cuit)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "select * from THE_RIGHT_JOIN.obtenerUnProveedor(@cuit)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@cuit", SqlDbType.VarChar).Value = cuit;
            DataSet ds = ConectorBDD.cargarDataSet(conn, cmd);

            String RS = ds.Tables[0].Rows[0]["Provee_RS"].ToString();
            String email = ds.Tables[0].Rows[0]["Provee_email"].ToString();
            Decimal telefono = Convert.ToDecimal(ds.Tables[0].Rows[0]["Provee_Telefono"]);
            String direccion = ds.Tables[0].Rows[0]["Provee_Dom"].ToString();
            String ciudad = ds.Tables[0].Rows[0]["Provee_Ciudad"].ToString();
            String rubro = ds.Tables[0].Rows[0]["Rubro_Descripcion"].ToString();
            int idRubro = Convert.ToInt32(ds.Tables[0].Rows[0]["Provee_Rubro"]);
            String contacto = ds.Tables[0].Rows[0]["Provee_contacto"].ToString();
            String postal = ds.Tables[0].Rows[0]["Provee_postal"].ToString();


            Proveedor provee = new Proveedor(RS, email, telefono, direccion, ciudad, cuit, rubro,idRubro, contacto, postal);
            return provee;
        }

        public static DataSet obtenerProveedores()
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "SELECT TOP 1000 [Provee_CUIT],[Provee_RS],[Rubro_Descripcion],[Provee_Dom],[Provee_Ciudad],[Provee_postal],[Provee_Telefono],[Provee_contacto],[Provee_email] FROM [GD2C2019].[THE_RIGHT_JOIN].[Proveedor] JOIN [GD2C2019].[THE_RIGHT_JOIN].[Rubro] ON ([Provee_Rubro] = [idRubro])";
            SqlCommand cmd = new SqlCommand(query, conn);
            return ConectorBDD.cargarDataSet(conn, cmd);
        }
        public static DataSet obtenerProveedoresRS()
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "SELECT TOP 1000 [Provee_CUIT],[Provee_RS] FROM THE_RIGHT_JOIN.Proveedor";
            SqlCommand cmd = new SqlCommand(query, conn);
            return ConectorBDD.cargarDataSet(conn, cmd);
        }

        public static String obtenerCuitDelUsuario(string username)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query = "SELECT Provee_CUIT from THE_RIGHT_JOIN.Usuario JOIN THE_RIGHT_JOIN.Proveedor ON (Usuari_CUIT = Provee_CUIT) where Usuari_Username = @username";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            DataSet ds = ConectorBDD.cargarDataSet(conn, cmd);
            return ds.Tables[0].Rows[0]["Provee_CUIT"].ToString();
        }

        public static DataSet generarQuerys(string RS, string cuit, string email)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);


            //--filtro por email
            if (RS == "" && cuit == "")
            {
                String query = "select TOP 1000 [Provee_CUIT],[Provee_RS],[Rubro_Descripcion],[Provee_Dom],[Provee_Ciudad],[Provee_postal],[Provee_Telefono],[Provee_contacto],[Provee_email] from THE_RIGHT_JOIN.Proveedor JOIN THE_RIGHT_JOIN.Rubro ON (Provee_Rubro = idRubro) WHERE Provee_email LIKE '%' + @email+ '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramEmail = cmd.Parameters.Add("@email", SqlDbType.VarChar);
                paramEmail.Value = email;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }

            //--filtro por RS
            if (email == "" && cuit == "")
            {
                String query = "select TOP 1000 [Provee_CUIT],[Provee_RS],[Rubro_Descripcion],[Provee_Dom],[Provee_Ciudad],[Provee_postal],[Provee_Telefono],[Provee_contacto],[Provee_email] from THE_RIGHT_JOIN.Proveedor JOIN THE_RIGHT_JOIN.Rubro ON (Provee_Rubro = idRubro) WHERE Provee_RS LIKE '%' + @RS+ '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramRS = cmd.Parameters.Add("@RS", SqlDbType.VarChar);
                paramRS.Value = RS;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }

            //--filtro por CUIT
            if (email == "" && RS == "")
            {
                String query = "select TOP 1000 [Provee_CUIT],[Provee_RS],[Rubro_Descripcion],[Provee_Dom],[Provee_Ciudad],[Provee_postal],[Provee_Telefono],[Provee_contacto],[Provee_email] from THE_RIGHT_JOIN.Proveedor JOIN THE_RIGHT_JOIN.Rubro ON (Provee_Rubro = idRubro) WHERE Provee_CUIT = @cuit";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramcuit = cmd.Parameters.Add("@cuit", SqlDbType.VarChar);
                paramcuit.Value = cuit;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }

            //--filtro por RS y email
            if (cuit == "" && email != "" && RS != "")
            {
                String query = "select TOP 1000 [Provee_CUIT],[Provee_RS],[Rubro_Descripcion],[Provee_Dom],[Provee_Ciudad],[Provee_postal],[Provee_Telefono],[Provee_contacto],[Provee_email] from THE_RIGHT_JOIN.Proveedor JOIN THE_RIGHT_JOIN.Rubro ON (Provee_Rubro = idRubro) WHERE Provee_RS LIKE '%' + @RS+ '%' AND Provee_email LIKE '%' + @email+ '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramEmail = cmd.Parameters.Add("@email", SqlDbType.VarChar);
                paramEmail.Value = email;
                SqlParameter paramRS = cmd.Parameters.Add("@RS", SqlDbType.VarChar);
                paramRS.Value = RS;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }

            //--filtro RS y cuit
            if (cuit != "" && email == "" && RS != "")
            {
                String query = "select TOP 1000 [Provee_CUIT],[Provee_RS],[Rubro_Descripcion],[Provee_Dom],[Provee_Ciudad],[Provee_postal],[Provee_Telefono],[Provee_contacto],[Provee_email] from THE_RIGHT_JOIN.Proveedor JOIN THE_RIGHT_JOIN.Rubro ON (Provee_Rubro = idRubro) WHERE Provee_CUIT = @cuit";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramcuit = cmd.Parameters.Add("@cuit", SqlDbType.VarChar);
                paramcuit.Value = cuit;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }

            //--filtro por los 3
            if (cuit != "" && email != "" && RS != "")
            {
                String query = "select TOP 1000 [Provee_CUIT],[Provee_RS],[Rubro_Descripcion],[Provee_Dom],[Provee_Ciudad],[Provee_postal],[Provee_Telefono],[Provee_contacto],[Provee_email] from THE_RIGHT_JOIN.Proveedor JOIN THE_RIGHT_JOIN.Rubro ON (Provee_Rubro = idRubro) WHERE Provee_CUIT = @cuit";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramcuit = cmd.Parameters.Add("@cuit", SqlDbType.VarChar);
                paramcuit.Value = cuit;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }
            return null;
        }

        public static void bajaProveedor(String cuit)
        {

            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.bajaProveedor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cuit", SqlDbType.VarChar).Value = cuit;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
                
        }

        public static void modificarProveedor(Proveedor provee)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.modificarProveedor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cuit", SqlDbType.VarChar).Value = provee.CUIT;
                    cmd.Parameters.Add("@RS", SqlDbType.VarChar).Value = provee.razon_social;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = provee.email;
                    cmd.Parameters.Add("@telefono", SqlDbType.Decimal).Value = provee.telefono;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = provee.direccion;
                    cmd.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = provee.ciudad;
                    cmd.Parameters.Add("@idRubro", SqlDbType.Int).Value = provee.idRubro;
                    cmd.Parameters.Add("@contacto", SqlDbType.VarChar).Value = provee.contacto;
                    cmd.Parameters.Add("@postal", SqlDbType.VarChar).Value = provee.postal;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}

