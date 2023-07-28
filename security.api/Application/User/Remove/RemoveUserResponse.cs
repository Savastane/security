


namespace security.api.Application.User.Remove
{
    using MediatR;

    public class RemoveUserResponse : IRequest<RemoveUserResponse>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }


        public dynamic Notifications { get; set; }

        public RemoveUserResponse(string id, string nome, string email, List<string> roles)
        {
            Nome = nome;
            Email = email;
            Roles = roles;
            Id = id;
        }

    }
}
