using System.Data;
using System.Data.SqlClient;

namespace ExempleDapper.ConnectionContext
{
    public class SqlConnectionContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _sqlSqlConnectionSting;
        private readonly string _sqlSqlConnectionStingV2;

        public SqlConnectionContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlSqlConnectionSting = _configuration.GetConnectionString("SqlConnectionString");
            _sqlSqlConnectionStingV2 = _configuration.GetConnectionString("SqlConnectionStringV2");
        }
        public IDbConnection CreateSqlconnection() => new SqlConnection(_sqlSqlConnectionSting);
        public IDbConnection CreateSqlconnection2() => new SqlConnection(_sqlSqlConnectionStingV2);

        //ของเดิม
        public IDbConnection CreateSqlconnectionV2()
        {
           return new SqlConnection(_sqlSqlConnectionSting);
        }
           

    }
}
