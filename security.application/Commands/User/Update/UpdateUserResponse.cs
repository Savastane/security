


namespace security.application
{
    using MediatR;

    public class UpdateUserResponse : IRequest<UpdateUserResponse>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }        
        public List<string> Roles { get; set; }

        
        public dynamic Notifications { get; set; }

        public UpdateUserResponse(string id, string nome, string email, List<string> roles)
        {
            this.Nome = nome;   
            this.Email = email; 
            this.Roles = roles; 
            this.Id = id;
        }

    }
}
