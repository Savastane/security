


namespace security.repository
{
    using security.domain;

    using Raven.Client.Documents.Session;
    using Raven.Client.Documents;


    public class UserRepository : IUsuarioRepository
    {
        private string DataBaseName;
        private  IAsyncDocumentSession session;

        public UserRepository(IAsyncDocumentSession dbSession)
        {
            
            this.session = dbSession;
            this.session.Advanced.SetTransactionMode(TransactionMode.ClusterWide);
         }            
                
        public Task<Usuario> GetById(string id)
        {   
                return session.LoadAsync<Usuario>("Usuarios/"+ id);
        }

        public Task<List<Usuario>> GetAll()
        {

            return session.Query<Usuario>()
                   .OrderBy(x => x.Id)
                   .ToListAsync();
        
        }

        public Task<Usuario> Add(Usuario entidade)
        {

      
            

                session.StoreAsync(entidade);
                session.SaveChangesAsync();

                return Task.FromResult(entidade);
            
        }

        public void Remove(Usuario entidade)
        {
            
                session.Delete(entidade.GetType() + "/" + entidade.Id);
                session.SaveChangesAsync();

                
        }

        public Task<Usuario> Update(Usuario entidade)
        {
            
                session.StoreAsync(entidade);
                session.SaveChangesAsync();

            return Task.FromResult(entidade);
        }
               

        public Task<Usuario> Authenticate(Usuario usuario)
        {            
            return GetByEmail(usuario.Email.Endereco);
        }


        public Task<Usuario> GetByEmail(string email)
        {
            var resultado = session.Query<Usuario>()
                      .Where(x => x.Email.Endereco == email)
                      .FirstOrDefaultAsync();

            return resultado;
        }

        public void SetDatabase(string databasename)
        {
            this.DataBaseName = databasename;

            if (DataBaseName != session.Advanced.DocumentStore.Database)
            {
                session = session.Advanced.DocumentStore.OpenAsyncSession(databasename);
            }

            

            
        }


        //public void UpdateIdentificacao(string id, Identificacao identificacao)
        //{

        //    session.Advanced.Patch<Usuario, Identificacao>(
        //                   $"usuarios/{id}" ,
        //                   x => x.Identificacao, identificacao);

        //    session.SaveChangesAsync();

        //}

    }
}
