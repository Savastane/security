

namespace security.application
{

    using MediatR;
    using security.domain;

    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserRequest, AuthenticateUserResponse>
    {
        private readonly IUsuarioRepository Repository;

        public AuthenticateUserHandler(IUsuarioRepository repository)
        {
            this.Repository = repository;
        }

        public Task<AuthenticateUserResponse> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {

            AuthenticateUserResponse resposta;


            Usuario user = new Usuario(request.Email, request.Password);


            var UserFound = this.Repository.Authenticate(user).Result;

            

            if (UserFound is null)
            {
                resposta = new AuthenticateUserResponse(request.Email);                
            }
            else
            {
                resposta = new AuthenticateUserResponse(UserFound.Nome , UserFound.Email.Endereco, "gerar token", UserFound.Roles, UserFound.GetPasswordInvalid(request.Password));

            }


            return Task.FromResult(resposta);

        }
    }
}
