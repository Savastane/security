namespace security.api.Application.User.Remove
{

    using MediatR;
    using security.domain;

    public class RemoveUserHandler : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        private readonly IUsuarioRepository rep;

        public RemoveUserHandler(IUsuarioRepository repository)
        {
            rep = repository;
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            RemoveUserResponse resposta;

            Usuario usuario = new Usuario(request.Nome, request.Email, request.Password, request.Roles);


            if (usuario.Notifications.Count > 0)
            {
                resposta = new RemoveUserResponse("0", usuario.Nome, usuario.Email.Endereco, usuario.Roles);
                resposta.Notifications = usuario.Notifications;
                return resposta;

            }

            rep.SetDatabase(request.Audiencia);
            var usuarioRetorno = rep.Add(usuario);
            var user = usuarioRetorno.Result;

            resposta = new RemoveUserResponse(user.Id, user.Nome, user.Email.Endereco, user.Roles);


            return resposta;

        }
    }
}
