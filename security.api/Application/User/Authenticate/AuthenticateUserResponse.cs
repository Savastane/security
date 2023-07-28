


namespace security.api.Application
{
    using MediatR;

    public class AuthenticateUserResponse : IRequest<AuthenticateUserResponse>
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public List<string> Roles;

        public bool EmailNaoEncontrado = true;
        public bool PasswordInvalido = true;

        public AuthenticateUserResponse(string email)
        {
            Email = email;
            EmailNaoEncontrado = true;
        }

        public AuthenticateUserResponse(string nome, string email, string token, List<string> roles, bool passwordInvalido)
        {
            Nome = nome;
            Email = email;
            Token = token;
            Roles = roles;
            EmailNaoEncontrado = false;
            PasswordInvalido = passwordInvalido;

        }




        public dynamic Notifications { get; set; }
    }
}
