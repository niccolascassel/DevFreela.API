namespace DevFreela.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string token)
        {
            Token = token;
            Email = email;
        }

        public string Token { get; private set; }
        public string Email { get; private set; }
    }
}
