using ExempleDapper.Models;

namespace ExempleDapper.Interfaces
{
    public interface IHomeland
    {
        public Task<IEnumerable<HomelandModel>> GetHomelandAllAsync();
        public Task<HomelandModel> GetHomelandByIdAsync(int id);
        public Task InsertHomelandAsync(HomelandNotId model);
        public Task UpdateHomelandAsync(int id,HomelandNotId model);
        public Task DeleteHomelandAsync(int  id);

    }
}
