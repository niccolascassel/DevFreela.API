using DevFreela.Application.Commands.CreateComment;
using FluentValidation;

namespace DevFreela.API.Validators
{
    public class CreateCommentCommandCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandCommandValidator()
        {
            RuleFor(p => p.Content)
                .MaximumLength(4000)
                .WithMessage("Content length must be lower or equal than 4000 chars!");
        }
    }
}
