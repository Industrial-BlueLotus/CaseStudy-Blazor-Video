using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MudBlazor;
using static MudBlazor.Icons;
using System.Security.Cryptography;

namespace Video2.Data
{
	public class MemberServices
	{
		// 
		// public readonly SqlConnConfig _conn;
		// private SqlConnection connection;
		//
		// public MemberServices(SqlConnConfig conn)
		// {
		// 	_conn = conn;
		// 	connection = new SqlConnection("Data Source=HIVI-PC\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
		// }
		private SqlConnection connection = new SqlConnection("Data Source=HIVI-PC\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
		


		public List<MemberModel> GetMemberList()
		{
			List<MemberModel> Lst = new List<MemberModel>();
            string DispMem = "Display_Members";
            SqlCommand cmd = new SqlCommand(DispMem,connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
		
			if (dt != null && dt.Rows.Count > 0)
			{
				for(int i=0;i<dt.Rows.Count;i++)
				{
					MemberModel obj = new MemberModel();
					obj.Cid = (int)dt.Rows[i]["Cid"];
					obj.Cname = dt.Rows[i]["Cname"].ToString();
					obj.NIC = (int?)dt.Rows[i]["NIC"];
					obj.mobile = (int?)dt.Rows[i]["mobile"];
					Lst.Add(obj);
		
				}
			}
			return Lst;
		}


		public void SaveMember(MemberModel mem)
		{
            string InstMem = "Insert_Members";
            SqlCommand cmd = new SqlCommand(InstMem, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
			SqlParameter Conname;
            Conname = cmd.Parameters.Add("@Cname", SqlDbType.NChar, 15);
            Conname.Value = mem.Cname;

            SqlParameter Cnic;
            Cnic = cmd.Parameters.Add("@NIC", SqlDbType.Int);
            Cnic.Value = mem.NIC;

            SqlParameter Cmobile;
            Cmobile = cmd.Parameters.Add("@mobile", SqlDbType.Int);
            Cmobile.Value = mem.mobile;

            //SqlCommand cmd = new SqlCommand("insert into Consumer(Cname,NIC,mobile) values ('"+mem.Cname+"','"+mem.NIC+"','"+mem.mobile+"')",connection);
            connection.Open();
			cmd.ExecuteNonQuery();
			connection.Close();
		}

		public void DeleteMember(int mem)
		{
			
            string DelMem = "Delete_Members";
            connection.Open();
            SqlCommand cmd = new SqlCommand(DelMem, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;
            param = cmd.Parameters.Add("@Cid", SqlDbType.Int);

            param.Value = mem;
            //SqlCommand cmd = new SqlCommand("DELETE FROM Consumer WHERE Cid=" + mem , connection);

            cmd.ExecuteNonQuery();
			connection.Close();
		}

	}
}
