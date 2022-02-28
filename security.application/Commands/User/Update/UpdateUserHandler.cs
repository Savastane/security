

namespace security.application
{

    using MediatR;
    using security.domain;

    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUsuarioRepository rep;

        public UpdateUserHandler(IUsuarioRepository repository)
        {
            rep = repository;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {

            UpdateUserResponse resposta ;

            Usuario usuario = new Usuario(request.Nome, request.Email, request.Password, request.Roles);


            if (usuario.Notifications.Count > 0)
            {
                resposta = new UpdateUserResponse("0", usuario.Nome, usuario.Email.Endereco, usuario.Roles);                
                resposta.Notifications = usuario.Notifications;
                return resposta;
                
            }

            rep.SetDatabase(request.Audiencia);
            var usuarioRetorno =  rep.Update(usuario);            
            var user = usuarioRetorno.Result;
            
            resposta = new UpdateUserResponse(user.Id, user.Nome, user.Email.Endereco, user.Roles);
                

            return resposta;

        }
    }
}
