using DevFreela.Application.Commands.UpdateProject;
using FluentValidation;

namespace DevFreela.API.Validators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
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
