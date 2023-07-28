namespace security.api.Application
{

    using MediatR;
    using security.api.Service;
    using security.api.Service.Interface;

    using security.domain;
    using security.jwt.settings;

    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserRequest, AuthenticateUserResponse>
    {
        private readonly IUsuarioRepository Repository;
        private readonly ITokenService TokenService;

        public AuthenticateUserHandler(IUsuarioRepository repository, ITokenService tokenService)
        {
            Repository = repository;
            TokenService = tokenService;
        }

        public Task<AuthenticateUserResponse> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {

            AuthenticateUserResponse resposta;


            Usuario user = new Usuario(request.Email, request.Password);


            var UserFound = Repository.Authenticate(user).Result;



            if (UserFound is null)
            {
                resposta = new AuthenticateUserResponse(request.Email);
            }
            else
            {
                resposta = new AuthenticateUserResponse(UserFound.Nome, UserFound.Email.Endereco, "gerar token", UserFound.Roles, UserFound.GetPasswordInvalid(request.Password));

            }


            TokenService.Generate(resposta);

            return Task.FromResult(resposta);

        }
    }
}
