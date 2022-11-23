using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Video2.Data
{
	public class ReUseSQL
	{
		public static SqlConnConfig _conn;
		public SqlConnection connection;

		public ReUseSQL(SqlConnConfig conn)
		{
			_conn = conn;
			connection = new SqlConnection(_conn.Value);
		}

		public async Task SaveRecord(string SQLStr)
		{
			connection.Open();
			SqlCommand cmd = new SqlCommand(SQLStr, connection);
			cmd.ExecuteNonQuery();
			connection.Close();
		}

		public DataTable GetRecord(string SQLStr)
		{
			
			SqlCommand cmd = new SqlCommand(SQLStr, connection);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			return dt;
		}
	}

	
}
