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
        public static DataSet obtenerClientes() {

            // string connString = @"Server =.\SQLSERVER2012; Database = GD2C2019;user id=gdCupon2019;pwd=gd2019";
           

                //define the query text
                string query = "SELECT TOP 1000 [Cli_Dni],[Cli_Nombre],[Cli_Apellido],[Cli_Mail],[Cli_Direccion],[Cli_Ciudad],[Cli_Fecha_Nac],[Cli_Telefono] FROM [GD2C2019].[THE_RIGHT_JOIN].[Cliente]";
                return ConectorBDD.cargarDataSet(query);                     
            
        }
    }
}
