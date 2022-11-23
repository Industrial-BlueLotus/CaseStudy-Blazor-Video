using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Video2.Data
{
    public class VideoModel
    {
        public int Vid { get; set; }
        public string Vname { get; set; }

        public string? LendLid { get; set; }
        public string? ReserveRid { get; set; }
    }
}
