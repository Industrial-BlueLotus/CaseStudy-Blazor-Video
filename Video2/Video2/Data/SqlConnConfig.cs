using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Video2.Data
{
	public class SqlConnConfig
	{
		public String Value { get; }

		public SqlConnConfig(string value) => Value = value;


	}
}
