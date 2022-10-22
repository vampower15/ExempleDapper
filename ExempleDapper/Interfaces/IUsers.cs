using ExempleDapper.Dto;
using ExempleDapper.Models;

namespace ExempleDapper.Interfaces
{
    public interface IUsers
    {
        public Task<IEnumerable<UsersModel>> GetUsersAllAsync();
        public Task<UsersModel> GetUsersByIdAsync(int id);
        public Task<UsersModel> GetUsersByNameAsync(string username, string password);
        public Task<UsersModel> InsertUsersAsync(UsersDto user);
        public Task UpdateUsersAsync(int id, UsersDto user);
        public Task DeleteUsersAsync(int id);
    }
}
