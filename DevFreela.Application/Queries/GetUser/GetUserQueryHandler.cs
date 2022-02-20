using DevFreela.Application.ViewModels;
using DevFreela.Core.Interfaces;
using MediatR;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IUserRepository repository;

        public GetUserQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserViewModel?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await repository.GetByIdAsync(request.Id);

            return user == null ? null : new UserViewModel(user.FullName, user.Email);
        }
    }
}
