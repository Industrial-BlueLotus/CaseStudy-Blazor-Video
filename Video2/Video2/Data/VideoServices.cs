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
    public class VideoServices
    {

        private SqlConnection connection = new SqlConnection("Data Source=HIVI-PC\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");

        public List<VideoModel> GetVideoList()
        {
            string DispVd = "Display_Video";
            List<VideoModel> VLst = new List<VideoModel>();
            SqlCommand cmd = new SqlCommand(DispVd, connection);
            cmd.CommandType = CommandType.StoredProcedure;
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
                    obj.ReserveRid = vdt.Rows[i]["ReserveRid"].ToString();
                    VLst.Add(obj);

                }
            }
            return VLst;
        }
        
        public void SaveVideo(VideoModel vid)
        {
            string InstVd = "Insert_Video";
            SqlCommand cmd = new SqlCommand(InstVd, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@Vname", SqlDbType.NChar, 15);

            param.Value = vid.Vname;

            connection.Open();
        	cmd.ExecuteNonQuery();
        	connection.Close();
        }

        public void DeleteVideo(int mem)
        { 

            string DelVd = "Delete_Video";
            connection.Open();
	        SqlCommand cmd = new SqlCommand(DelVd, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@Vid", SqlDbType.Int);

            param.Value = mem;

            cmd.ExecuteNonQuery();
	        connection.Close();
        }


	}
}
