namespace security.api.Application
{

    using MediatR;
    using security.domain;

    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IUsuarioRepository rep;

        public AddUserHandler(IUsuarioRepository repository)
        {
            rep = repository;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            AddUserResponse resposta;

            Usuario usuario = new Usuario(request.Nome, request.Email, request.Password, request.Roles);


            if (usuario.Notifications.Count > 0)
            {
                resposta = new AddUserResponse("0", usuario.Nome, usuario.Email.Endereco, usuario.Roles);
                resposta.Notifications = usuario.Notifications;
                return resposta;

            }

            rep.SetDatabase(request.Audiencia);
            var usuarioRetorno = rep.Add(usuario);
            var user = usuarioRetorno.Result;

            resposta = new AddUserResponse(user.Id, user.Nome, user.Email.Endereco, user.Roles);


            return resposta;

        }
    }
}
