namespace security.api.Application.User.Update
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
            Nome = nome;
            Email = email;
            Roles = roles;
            Password = password;
        }

    }
}
