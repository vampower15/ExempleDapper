using ExempleDapper.Models;

namespace ExempleDapper.Interfaces
{
    public interface IThailandPost
    {
        public Task<IEnumerable<ThailandPostModel>> GetThailandPostAsync();

        public Task<ThailandPostModel> GetThailandPostByIdAsync(string id);
        public Task InsertThailandPostAsync(ThailandPostModel model);
        public Task UpdateThailandPostAsync(string id,ThailandPostModel model);
        public Task DeleteThailandPostAsync(string id);

    }
}
