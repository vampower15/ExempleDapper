using ExempleDapper.Dto;
using ExempleDapper.Models;

namespace ExempleDapper.Interfaces
{
    public interface IUserRole
    {
        public Task<IEnumerable <UserRolesModel>> GetUserRoleAll();
        public Task<UserRolesModel> GetUserRoleByUserId(int id);
        public Task InsertUserRole(UserRoleDto user);
        public Task UpdateUserRole(int id,UserRoleDto user);
        public Task DeleteUserRoleByUserId(int id);
    }
}
