using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces;
using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository repository;

        public CreateProjectCommandHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.ClientId, request.FreelancerId, request.TotalCost);

            await repository.AddAsync(project);

            return project.Id;
        }
    }
}
