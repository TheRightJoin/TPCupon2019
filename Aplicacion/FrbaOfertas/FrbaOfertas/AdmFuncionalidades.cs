using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
	class AdmFuncionalidades
	{
		public static DataSet obtenerFuncxRol(int idRol)
		{
			string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
			SqlConnection conn = new SqlConnection(connString);
			String query = "SELECT * FROM THE_RIGHT_JOIN.traerFuncDelRol(@rol)";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.Add("@rol", SqlDbType.Int).Value = idRol;
			return ConectorBDD.cargarDataSet(conn, cmd);
		}

	}
}
