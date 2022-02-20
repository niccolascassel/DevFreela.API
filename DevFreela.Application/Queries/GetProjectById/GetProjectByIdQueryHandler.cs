using DevFreela.Application.ViewModels;
using DevFreela.Core.Interfaces;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository repository;

        public GetProjectByIdQueryHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ProjectDetailsViewModel?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await repository.GetByIdAsync(request.Id);

            return 
                project == null ?
                null :
                new ProjectDetailsViewModel(
                    project.Id,
                    project.Title,
                    project.Description,
                    project.TotalCost,
                    project.StartedAt,
                    project.FinishedAt,
                    project.Client.FullName,
                    project.Freelancer.FullName
                );
        }
    }
}
