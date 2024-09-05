using FINSHARK.Models;

namespace FINSHARK.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreatAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id ,Comment commentModel);
        Task<Comment?> DeleteAsync(int id);
    }
}
