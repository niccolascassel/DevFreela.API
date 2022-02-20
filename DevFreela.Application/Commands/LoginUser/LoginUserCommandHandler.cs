using DevFreela.Application.ViewModels;
using DevFreela.Core.Interfaces;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository repository;
        private readonly IAuthService authService;

        public LoginUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            this.repository = repository;
            this.authService = authService;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = authService.ComputeSha256Hash(request.Password);            

            var user = await repository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                return null;

            var token = authService.GenerateJwtToken(user.Email, user.Role);

            var loginUserViewModel = new LoginUserViewModel(user.Email, token);

            return loginUserViewModel;
        }
    }
}
