using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Video2.Data
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; set; }

		public void ConfigureServices(IServiceCollection services)
		{
			SqlConnection SQLConnconfig = new SqlConnection(Configuration.GetConnectionString("MySQLDBContext"));
			services.AddSingleton(SQLConnconfig);
			services.AddServerSideBlazor(x => x.DetailedErrors = true);
			// services.AddTransient<MemberServices>();
		}

	}
}
