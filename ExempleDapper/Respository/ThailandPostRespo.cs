using Dapper;
using ExempleDapper.ConnectionContext;
using ExempleDapper.Interfaces;
using ExempleDapper.Models;
using IdentityModel.Client;
using System.Data;

namespace ExempleDapper.Respository
{
    public class ThailandPostRespo : IThailandPost
    {
        private readonly SqlConnectionContext _sqlConnectionContext;
      
        public ThailandPostRespo(SqlConnectionContext sqlConnectionContext)
        {
            _sqlConnectionContext = sqlConnectionContext;
        }

        //All
        public async Task<IEnumerable<ThailandPostModel>> GetThailandPostAsync()
        {
            string storeProcedure = "spThailandPostAll";
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection2())
            {
                var states = await connection.QueryAsync<ThailandPostModel>(storeProcedure, commandType: CommandType.StoredProcedure);
                return states;
            }
        }

        //ById
        public async Task<ThailandPostModel> GetThailandPostByIdAsync(string id)
        {
            string storeProcedure = "spThailandPostById";
            var parameters = new DynamicParameters();
            parameters.Add("POI_ZIP_CODE", id, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection2())
            {
                var state = await connection.QueryFirstOrDefaultAsync<ThailandPostModel>(storeProcedure,parameters,commandType: CommandType.StoredProcedure);
            return state;
            }
        }

        //Insert
        public async Task InsertThailandPostAsync(ThailandPostModel model)
        {
            string storeProcedure = "spInsertThailandPost";
            var parameters = new DynamicParameters();
            parameters.Add("POI_ZIP_CODE", model.ZipCode, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_POST_OFFICE_NAME", model.OfficeName, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_BRANCH", model.Branch, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_ADDRESS", model.Address, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_PHONE", model.Phone, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_WORKING_DAY", model.WorkingDay, DbType.String, ParameterDirection.Input);

            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection2())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateThailandPostAsync(string id, ThailandPostModel model)
        {
            string storeProcedure = "spUpdateThailandPost";
            var parameters = new DynamicParameters();
            parameters.Add("POI_ZIP_CODE", model.ZipCode, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_POST_OFFICE_NAME", model.OfficeName, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_BRANCH", model.Branch, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_ADDRESS", model.Address, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_PHONE", model.Phone, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_WORKING_DAY", model.WorkingDay, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection2())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task DeleteThailandPostAsync(string id)
        {
            string storeProcedure = "spDeleteThailandPost";
            var parameters = new DynamicParameters();
            parameters.Add("POI_ZIP_CODE", id, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection2())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
