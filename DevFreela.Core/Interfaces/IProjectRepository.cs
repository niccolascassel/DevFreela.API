using DevFreela.Core.Entities;

namespace DevFreela.Core.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task SaveChangesAsync();
        Task DeleteAsync(Project project);        
        Task StartAsync(Project project);
        Task FinishAsync(Project project);
        Task AddCommentAsync(ProjectComment comment);
    }
}
