namespace security.api.Application
{

    using MediatR;
    using security.domain;

    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IUsuarioRepository rep;

        public GetUserHandler(IUsuarioRepository repository)
        {
            rep = repository;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            GetUserResponse resposta;



            rep.SetDatabase(request.GetBanco());
            var usuarioRetorno = rep.Add(null);
            var user = usuarioRetorno.Result;

            resposta = new GetUserResponse(user.Id, user.Nome, user.Email.Endereco, user.Roles);


            return resposta;

        }
    }
}
