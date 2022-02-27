


namespace security.application
{
    using MediatR;

    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

        public string Audiencia;

        public UpdateUserRequest(string nome, string email, string password, List<string> roles)
        {
            this.Nome = nome;
            this.Email = email;
            this.Roles = roles;
            this.Password = password;   
        }

    }
}
