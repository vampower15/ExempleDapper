using Dapper;
using ExempleDapper.ConnectionContext;
using ExempleDapper.Interfaces;
using ExempleDapper.Models;
using Microsoft.Ajax.Utilities;
using System.Data;

namespace ExempleDapper.Respository
{
    public class StatusRepository : IStatus
    {
        private readonly SqlConnectionContext _Context;
        public StatusRepository(SqlConnectionContext context)
        {
            _Context = context;
        }
        public async Task<StatusModel> GetStatusById(int id)
        {
            string storedProcedureName = "uspGetStatusById";
            var parameters = new DynamicParameters();
            parameters.Add("StatusId", id, DbType.Int32);
            using (var connection = _Context.CreateSqlconnection())
            {
                var status = await connection.QuerySingleOrDefaultAsync<StatusModel>(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
                return status;
            }
        }
    }
}
