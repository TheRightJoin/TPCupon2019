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
    class AdmUsuario
    {
        public static void altaUsuario(Usuario user)
        {


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

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}