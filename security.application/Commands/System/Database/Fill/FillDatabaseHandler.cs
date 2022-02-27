

namespace security.application
{

    using MediatR;
    using security.domain;

    public class FillDatabaseHandler : IRequestHandler<FillDatabaseRequest, FillDatabaseResponse>
    {
        private readonly IUsuarioRepository Repository;

        public FillDatabaseHandler(IUsuarioRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<FillDatabaseResponse> Handle(FillDatabaseRequest request, CancellationToken cancellationToken)
        {
            Repository.SetDatabase(request.Audiencia);
            
            var usuarios = Usuario.GetMoq();
            var lista = new List<UsuarioResponse>();

            foreach (var item in usuarios)
            {
                var user = Repository.Add(item).Result;
                lista.Add(new UsuarioResponse(user.Nome, user.Email.Endereco, user.Password, user.Roles));
            }

            return new FillDatabaseResponse(lista, "Adicinados dois usuários no banco ");

        }
    }
}
