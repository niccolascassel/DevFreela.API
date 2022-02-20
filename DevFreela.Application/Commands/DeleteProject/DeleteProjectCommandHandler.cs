using DevFreela.Core.Interfaces;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository repository;

        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await repository.GetByIdAsync(request.Id);

            await repository.DeleteAsync(project);

            return Unit.Value;
        }
    }
}
