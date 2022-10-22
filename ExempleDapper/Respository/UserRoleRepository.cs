using Dapper;
using ExempleDapper.ConnectionContext;
using ExempleDapper.Dto;
using ExempleDapper.Interfaces;
using ExempleDapper.Models;
using System.Data;

namespace ExempleDapper.Respository
{
    public class UserRoleRepository : IUserRole
    {
        private readonly SqlConnectionContext _Context;
        public UserRoleRepository(SqlConnectionContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<UserRolesModel>> GetUserRoleAll()
        {
            string storedProcedureName = "uspGetUserRoles";
            using (var connection = _Context.CreateSqlconnection())
            {
                var userRoles = await connection.QueryAsync<UserRolesModel>(storedProcedureName, commandType: CommandType.StoredProcedure);
                return userRoles.ToList();
            }
        }

        public async Task<UserRolesModel> GetUserRoleByUserId(int id)
        {
            string storedProcedureName = "uspGetUserRolesByUserId";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", id, DbType.Int32);
            using (var connection = _Context.CreateSqlconnection())
            {
                var userRole = await connection.QuerySingleOrDefaultAsync<UserRolesModel>(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
                return userRole;
            }
        }

        public async Task InsertUserRole(UserRoleDto user)
        {
            string storedProcedureName = "uspInsertUserRoles";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", user.UserId, DbType.Int32);
            parameters.Add("RoleId", user.RoleId, DbType.Int32);
            using (var connection = _Context.CreateSqlconnection())
            {
                var resutl = await connection.ExecuteAsync(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public async Task UpdateUserRole(int id, UserRoleDto user)
        {
            string storedProcedureName = "uspUpdateUserRoles";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", id, DbType.Int32);
            parameters.Add("RoleId", user.RoleId, DbType.Int32);
            using (var connection = _Context.CreateSqlconnection())
            {
                var resutl = await connection.ExecuteAsync(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public async Task DeleteUserRoleByUserId(int id)
        {
            string storedProcedureName = "uspDeleteUserRoles";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", id, DbType.Int32);
            using (var connection = _Context.CreateSqlconnection())
            {
                var resutl = await connection.ExecuteAsync(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
