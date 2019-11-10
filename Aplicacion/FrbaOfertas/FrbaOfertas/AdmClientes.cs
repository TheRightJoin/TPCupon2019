﻿using System;
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
            SqlCommand cmd = new SqlCommand(query, conn);
            return ConectorBDD.cargarDataSet(conn,cmd);

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
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static DataSet generarQuerys(String dni, String nombre, String apellido)
        {
           
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString); 
            if (nombre == "" && apellido == "")
            {
                String query = "select * from THE_RIGHT_JOIN.Cliente WHERE Cli_Dni = @dni";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramDni = cmd.Parameters.Add("@dni", SqlDbType.Decimal);
                paramDni.Value = Convert.ToDecimal(dni);
                return ConectorBDD.cargarDataSet(conn, cmd);
            }
            if (dni == "" && nombre == "")
            {
                String query = "select * from THE_RIGHT_JOIN.Cliente WHERE Cli_Apellido LIKE '%' + @apellido + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramApellido = cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
                paramApellido.Value = apellido;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }
            if (dni == "" && apellido == "")
            {
                String query = "select * from THE_RIGHT_JOIN.Cliente WHERE Cli_Nombre LIKE '%' + @nombre + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramNombre = cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                paramNombre.Value = nombre;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }
            if (dni == "" && apellido != "" && nombre != "")
            {
                String query = "select * from THE_RIGHT_JOIN.Cliente WHERE Cli_Nombre LIKE '%' + @nombre + '%' AND Cli_Apellido LIKE '%' + @apellido + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramNombre = cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                paramNombre.Value = nombre;
                SqlParameter paramApellido = cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
                paramApellido.Value = apellido;
                return ConectorBDD.cargarDataSet(conn, cmd);
            }
            if (dni != "" && apellido != "" && nombre != "")
            {
                String query = "select * from THE_RIGHT_JOIN.Cliente WHERE Cli_Nombre LIKE '%' + @nombre + '%' AND Cli_Apellido LIKE '%' + @apellido + '%' AND Cli_Dni = @dni";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramNombre = cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                paramNombre.Value = nombre;
                SqlParameter paramApellido = cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
                paramApellido.Value = apellido;
                SqlParameter paramDni = cmd.Parameters.Add("@dni", SqlDbType.Decimal);
                paramDni.Value = Convert.ToDecimal(dni);
                return ConectorBDD.cargarDataSet(conn, cmd);
            }
            
            return null;
           
        }
    }
}
