using DevFreela.Core.Interfaces;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository repository;

        public UpdateProjectCommandHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await repository.GetByIdAsync(request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);

            await repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
