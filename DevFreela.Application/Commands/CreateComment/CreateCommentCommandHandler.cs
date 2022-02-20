using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IProjectRepository repository;

        public CreateCommentCommandHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);

            await repository.AddCommentAsync(comment);

            return comment.Id;
        }
    }
}
