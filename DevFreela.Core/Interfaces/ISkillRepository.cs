using DevFreela.Core.Entities;

namespace DevFreela.Core.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
    }
}
