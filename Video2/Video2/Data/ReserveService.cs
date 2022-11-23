using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MudBlazor;
using static MudBlazor.Icons;

namespace Video2.Data
{
	public class ReserveService
	{
		private SqlConnection connection = new SqlConnection("Data Source=HIVI-PC\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");



		public List<ReserveModel> GetReserveList()
		{
			List<ReserveModel> Lst = new List<ReserveModel>();
            string DispRes = "Display_Reserve_Rec";
            SqlCommand cmd = new SqlCommand(DispRes, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            //SqlCommand cmd = new SqlCommand("Select * from Reserve", connection);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			if (dt != null && dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					ReserveModel obj = new ReserveModel();
					obj.Cid = (int)dt.Rows[i]["Cid"];
					obj.Vid = (int)dt.Rows[i]["Vid"];
					obj.StartDate = Convert.ToDateTime(dt.Rows[i]["StartDate"].ToString());
					obj.DueDate = Convert.ToDateTime(dt.Rows[i]["DueDate"].ToString());
					Lst.Add(obj);

				}
			}
			return Lst;
		}


		public void SaveReservation(ReserveModel mem)
		{
            string InstRes = "Insert_Reserve";
            SqlCommand cmd = new SqlCommand(InstRes, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Conid;
            Conid = cmd.Parameters.Add("@Cid", SqlDbType.Int);
            Conid.Value = mem.Cid;

            SqlParameter Vidid;
            Vidid = cmd.Parameters.Add("@Vid", SqlDbType.Int);
            Vidid.Value = mem.Vid;

            SqlParameter start;
            start = cmd.Parameters.Add("@StartDate", SqlDbType.Date);
            start.Value = mem.StartDate;

            SqlParameter due;
            due = cmd.Parameters.Add("@DueDate", SqlDbType.Date);
            due.Value = mem.DueDate;

            //SqlCommand cmd = new SqlCommand("insert into Reserve(Cid,Vid,StartDate,DueDate) values ('" + mem.Cid + "','" + mem.Vid + "','" + mem.StartDate + "','" +mem.DueDate+ "')", connection);
            connection.Open();
			cmd.ExecuteNonQuery();
			connection.Close();
		}

		public void DeleteReservation(int Cid,int Vid)
		{
            string DelRes = "Delete_Reserve_Rec";
            connection.Open();
            SqlCommand cmd = new SqlCommand(DelRes, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Coid;
            Coid = cmd.Parameters.Add("@Cid", SqlDbType.Int);
            Coid.Value = Cid;

            SqlParameter Viid;
            Viid = cmd.Parameters.Add("@Vid", SqlDbType.Int);
            Viid.Value = Vid;

            //SqlCommand cmd = new SqlCommand("DELETE FROM Reserve WHERE Cid="+Cid+" and Vid="+Vid+"", connection);

            cmd.ExecuteNonQuery();
			connection.Close();
		}

	}
}
