using Dapper;
using ExempleDapper.ConnectionContext;
using ExempleDapper.Interfaces;
using ExempleDapper.Models;
using System.Data;
using System.Data.SqlTypes;

namespace ExempleDapper.Respository
{
    public class HomelandRepository : IHomeland
    {
        private readonly SqlConnectionContext _sqlConnectionContext;

        public HomelandRepository(SqlConnectionContext sqlConnectionContext)
        {
        _sqlConnectionContext = sqlConnectionContext;
        }

        //All
        public async Task<IEnumerable<HomelandModel>> GetHomelandAllAsync()
        {
            string storeProcedure = "SPHomelandAll";
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
            {
                var books = await connection.QueryAsync<HomelandModel>(storeProcedure, commandType: CommandType.StoredProcedure);
                return books;
            }
        }

        //ById
        public async Task<HomelandModel> GetHomelandByIdAsync(int id)
        {  
            string storeProcedure = "SPGetHomelandById";
            var parameters = new DynamicParameters();
            parameters.Add("IdBk", id, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
            {
                var book = await connection.QueryFirstOrDefaultAsync<HomelandModel>(storeProcedure,parameters,commandType: CommandType.StoredProcedure);
                return book;
            }
        }

        //Insert
        public async Task InsertHomelandAsync(HomelandNotId model)
        {
            string storeProcedure = "SPInsertHomeland";
            var parameters = new DynamicParameters();
            parameters.Add("NameBk", model.NameBk, DbType.String, ParameterDirection.Input);
            parameters.Add("WriterBk", model.WriterBk, DbType.String, ParameterDirection.Input);
            parameters.Add("CategoryBk", model.CategoryBk, DbType.String, ParameterDirection.Input);
            parameters.Add("PublisherBk", model.PublisherBk, DbType.String, ParameterDirection.Input);
            parameters.Add("PageBk",model.PageBk, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ReleaseDateBK", model.ReleaseDateBk, DbType.String, ParameterDirection.Input);
            parameters.Add("PriceBk",model.PriceBk, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        //Update
        public async Task UpdateHomelandAsync(int id, HomelandNotId model)
        {
                       
                string storeProcedure = "SPUpdateHomeland";
                var parameters = new DynamicParameters();
                parameters.Add("IdBk", id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NameBk", model.NameBk, DbType.String, ParameterDirection.Input);
                parameters.Add("WriterBk", model.WriterBk, DbType.String, ParameterDirection.Input);
                parameters.Add("CategoryBk", model.CategoryBk, DbType.String, ParameterDirection.Input);
                parameters.Add("PublisherBk", model.PublisherBk, DbType.String, ParameterDirection.Input);
                parameters.Add("PageBk",model.PageBk, DbType.Int32, ParameterDirection.Input);
                parameters.Add("ReleaseDateBk", model.ReleaseDateBk, DbType.String, ParameterDirection.Input);
                parameters.Add("PriceBk",model.PriceBk, DbType.Int32, ParameterDirection.Input);
                using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
                {
                    await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
                }                      
        }

        //Delete
        public async Task DeleteHomelandAsync(int id)
        {
            string storeProcedure = "SPDeleteHomeland";
            var parameters = new DynamicParameters();
            parameters.Add("IdBk", id, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
