


namespace security.application
{
    using MediatR;

    public class FillDatabaseResponse : IRequest<FillDatabaseResponse>
    {
        public String Mensagem{ get; set; }
        public List<UsuarioResponse> Usuarios { get; set; }


        public FillDatabaseResponse(List<UsuarioResponse> usuarios, string mensagem)
        {
            
            this.Usuarios = usuarios;
            this.Mensagem = mensagem;
            
        }
            

    }

    public class UsuarioResponse
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

        public UsuarioResponse( string nome, string email, string password, List<string> roles)
        {
            this.Nome = nome;
            this.Email = email;
            this.Roles = roles;
            this.Password = password;



    }
    }
}
