


namespace security.application
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
            this.Email = email;
            this.EmailNaoEncontrado = true;
        }

        public AuthenticateUserResponse(string nome, string email, string token, List<string> roles, bool passwordInvalido )
        {
            this.Nome = nome;
            this.Email = email;
            this.Token = token;
            this.Roles = roles;
            this.EmailNaoEncontrado = false;
            this.PasswordInvalido = passwordInvalido;

        }

        


        public dynamic Notifications { get; set; }
    }
}
