using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository repository;
        private readonly IAuthService authService;

        public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            this.repository = repository;
            this.authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = authService.ComputeSha256Hash(request.Password);
            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await repository.AddAsync(user);

            return user.Id;
        }
    }
}
