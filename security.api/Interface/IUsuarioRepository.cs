


namespace security.Interface
{
    using security.domain;
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByEmail(string email);
        Task<Usuario> GetById(string Id);
        Task<Usuario> Add(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Authenticate(Usuario usuario);

        void Remove(Usuario usuario);
        void SetDatabase(string databasename);


    }
}
