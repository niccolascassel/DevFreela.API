using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
