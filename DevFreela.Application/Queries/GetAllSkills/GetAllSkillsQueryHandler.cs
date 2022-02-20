using DevFreela.Application.ViewModels;
using DevFreela.Core.Interfaces;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository repository;

        public GetAllSkillsQueryHandler(ISkillRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await repository.GetAllAsync();

            var skillsViewModel =
                skills
                    .Select(p => new SkillViewModel(p.Id, p.Description))
                    .ToList();

            return skillsViewModel;
        }
    }
}
