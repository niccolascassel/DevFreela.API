using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
