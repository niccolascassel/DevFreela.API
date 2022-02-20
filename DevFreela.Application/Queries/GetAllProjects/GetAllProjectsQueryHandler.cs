using DevFreela.Application.ViewModels;
using DevFreela.Core.Interfaces;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository repository;

        public GetAllProjectsQueryHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await repository.GetAllAsync();

            var projectsViewModel = 
                    projects
                        .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                        .ToList();

            return projectsViewModel;
        }
    }
}
