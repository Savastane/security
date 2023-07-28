namespace security.api.Application
{
    using MediatR;

    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

        public string Audiencia;

        public AddUserRequest(string nome, string email, string password, List<string> roles)
        {
            Nome = nome;
            Email = email;
            Roles = roles;
            Password = password;
        }

    }
}
