using Dapper;
using ExempleDapper.ConnectionContext;
using ExempleDapper.Dto;
using ExempleDapper.Interfaces;
using ExempleDapper.Models;
using Intercom.Data;
using MediaBrowser.Model.Dto;
using Microsoft.Ajax.Utilities;
using System.Data;
using System.Data.SqlTypes;

namespace ExempleDapper.Respository
{
    public class UserRepository : IUsers
    {
        private readonly SqlConnectionContext _Context;
        
        public UserRepository(SqlConnectionContext sqlConnectionContext)
        {
            _Context = sqlConnectionContext;   
        }
        //All
        public async Task<IEnumerable<UsersModel>> GetUsersAllAsync()
        {
            string storeProcedure = "SPUsersAll";
            using(IDbConnection connection = _Context.CreateSqlconnection())
            {
                var users = await connection.QueryAsync<UsersModel>(storeProcedure,commandType:CommandType.StoredProcedure);
                return users;
            }
        }

        //ById
        public async Task<UsersModel> GetUsersByIdAsync(int id)
        {
            string storeProcedure = "SPGetUsersById";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", id,DbType.Int32,ParameterDirection.Input);
            using (IDbConnection connection = _Context.CreateSqlconnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<UsersModel>(storeProcedure,parameters,commandType:CommandType.StoredProcedure);
                return user;
            }
        }

        public async Task<UsersModel> GetUsersByNameAsync(string username, string password)
        {
            string storedProcedureName = "spGetUsersByUsername";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", username, DbType.String);
            parameters.Add("Password", password, DbType.String);
            using (var connection = _Context.CreateSqlconnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<UsersModel>(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
                return user;
            }
        }

        //Insert
        public async Task<UsersModel> InsertUsersAsync(UsersDto user)
        {
            string storedProcedureName = "SPInsertUsers";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", user.UserName, DbType.String);
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("StatusId", user.StatusId, DbType.Int32);
            using (var connection = _Context.CreateSqlconnection())
            {
                var id = await connection.QuerySingleAsync<int>(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
                var userDto = new UsersModel
                {
                    UserId = id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    StatusId = user.StatusId
                };

                return userDto;
            }
        }

        //Update
        public async Task UpdateUsersAsync(int id, UsersDto user)
        {
            string storeProcedure = "SPUpdateUsers";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Username", user.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", user.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", user.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("StatusId", user.StatusId, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _Context.CreateSqlconnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        //Delete
        public async Task DeleteUsersAsync(int id)
        {
            string storeProcedure = "SPDeleteUsers";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", id, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _Context.CreateSqlconnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}