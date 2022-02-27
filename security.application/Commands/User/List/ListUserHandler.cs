

namespace security.application
{

    using MediatR;
    using security.domain;

    public class ListUserHandler : IRequestHandler<ListUserRequest, ListUserResponse>
    {
        private readonly IUsuarioRepository rep;

        public ListUserHandler(IUsuarioRepository repository)
        {
            rep = repository;
        }

        public async Task<ListUserResponse> Handle(ListUserRequest request, CancellationToken cancellationToken)
        {
            ListUserResponse resposta ;

            Usuario usuario = new Usuario(request.Nome, request.Email, request.Password, request.Roles);


            if (usuario.Notifications.Count > 0)
            {
                resposta = new ListUserResponse("0", usuario.Nome, usuario.Email.Endereco, usuario.Roles);                
                resposta.Notifications = usuario.Notifications;
                return resposta;
                
            }

            rep.SetDatabase(request.Audiencia);
            var usuarioRetorno =  rep.Add(usuario);            
            var user = usuarioRetorno.Result;
            
            resposta = new ListUserResponse(user.Id, user.Nome, user.Email.Endereco, user.Roles);
                

            return resposta;

        }
    }
}
