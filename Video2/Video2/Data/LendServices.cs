using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MudBlazor;
using static MudBlazor.Icons;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.Common;
using System.Security.Cryptography;

namespace Video2.Data
{
	public class LendServices
	{
		 SqlConnection connection = new SqlConnection("Data Source=HIVI-PC\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");

		public List<VideoModel> GetLendList()
		{
			List<VideoModel> VLst = new List<VideoModel>();
            string DispLend = "Display_Lended";
            SqlCommand cmd = new SqlCommand(DispLend, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            //SqlCommand cmd = new SqlCommand("Select * from Video where LendLid is not NUll", connection);
			SqlDataAdapter vda = new SqlDataAdapter(cmd);
			DataTable vdt = new DataTable();
			vda.Fill(vdt);
		
			if (vdt != null && vdt.Rows.Count > 0)
			{
				for (int i = 0; i < vdt.Rows.Count; i++)
				{
					VideoModel obj = new VideoModel();
					obj.Vid = (int)vdt.Rows[i]["Vid"];
					obj.Vname = vdt.Rows[i]["Vname"].ToString();
					obj.LendLid = vdt.Rows[i]["LendLid"].ToString();
					
					VLst.Add(obj);
		
				}
			}
			return VLst;
		}
		public bool CheckVideo(int vid)
		{


			connection.Open();
			SqlCommand cmd = new SqlCommand("Select * from Video where LendLid is null and Vid=" + vid, connection);
			SqlDataReader reader = cmd.ExecuteReader();

			

			if (reader.HasRows)
			{
				return true;


			}
			else
			{
				return false;

			}
			cmd.ExecuteNonQuery();
			connection.Close();

		}

		public void LendVideo(int cid,int vid)
		{
            string InstLend = "Lend_Videos";
            SqlCommand cmd = new SqlCommand(InstLend, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Cnid;
            Cnid = cmd.Parameters.Add("@Cid", SqlDbType.Int);
            Cnid.Value = cid;

            SqlParameter viid;
            viid = cmd.Parameters.Add("@Vid", SqlDbType.Int);
            viid.Value = vid;
            connection.Open();

			//SqlCommand cmd = new SqlCommand("UPDATE Video SET LendLid = "+cid+" WHERE Vid = " + vid, connection);

			cmd.ExecuteNonQuery();
			connection.Close();
		}
		public void DeleteLendVideo(int mem)
		{
            string DelLend = "Delete_Lended_Videos";
            connection.Open();
            SqlCommand cmd = new SqlCommand(DelLend, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter vide;
            vide = cmd.Parameters.Add("@Vid", SqlDbType.Int);
            vide.Value = mem;


			//SqlCommand cmd = new SqlCommand("UPDATE Video SET LendLid = NULL WHERE Vid = " + mem, connection);

			cmd.ExecuteNonQuery();
			connection.Close();
		}
	}
}
