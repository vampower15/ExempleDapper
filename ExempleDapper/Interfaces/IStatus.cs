using ExempleDapper.Models;

namespace ExempleDapper.Interfaces
{
    public interface IStatus
    {
        Task<StatusModel> GetStatusById(int id);
    }
}
