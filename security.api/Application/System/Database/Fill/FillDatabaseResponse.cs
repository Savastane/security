


namespace security.api.Application
{
    using MediatR;

    public class FillDatabaseResponse : IRequest<FillDatabaseResponse>
    {
        public string Mensagem { get; set; }
        public List<UsuarioResponse> Usuarios { get; set; }


        public FillDatabaseResponse(List<UsuarioResponse> usuarios, string mensagem)
        {

            Usuarios = usuarios;
            Mensagem = mensagem;

        }


    }

    public class UsuarioResponse
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

        public UsuarioResponse(string nome, string email, string password, List<string> roles)
        {
            Nome = nome;
            Email = email;
            Roles = roles;
            Password = password;



        }
    }
}
