using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Video2.Data
{
	public class MemberModel
	{
		public int Cid { get; set; }
		public string Cname { get; set; }

		public int? NIC { get; set; }
		public int? mobile { get; set; }
	}
}
