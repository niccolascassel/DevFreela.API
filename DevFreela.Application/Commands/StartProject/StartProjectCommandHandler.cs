using DevFreela.Core.Interfaces;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository repository;

        public StartProjectCommandHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await repository.GetByIdAsync(request.Id);

            project.Start();

            await repository.StartAsync(project);

            return Unit.Value;
        }
    }
}
