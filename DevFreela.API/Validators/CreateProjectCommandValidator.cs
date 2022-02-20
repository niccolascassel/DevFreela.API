using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.API.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Description length must be lower or equal than 255 chars!");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Title length must be lower or equal than 255 chars!");
        }
    }
}
