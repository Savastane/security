

namespace security.test.Application
{
    using security.domain;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class MockAutentircarRepository
    {
        public static void Inicializar(string email, string senha)
        {
            MockAutentircarRepository.userAuthenticate = new (email, senha);
        }

        public static Usuario userAuthenticate = Usuario.GetMoq().FirstOrDefault();

        public static Mock<IUsuarioRepository> getLoginRepository()        {

            var lista = Usuario.GetMoq();


            var moqResult = new Mock<IUsuarioRepository>();


            moqResult.Setup( r=> r.Authenticate(It.IsAny<Usuario>())).ReturnsAsync((Usuario user) => {
                
                var loginTeste = lista.Where(r => r.Email.Endereco == MockAutentircarRepository.userAuthenticate.Email.Endereco ).FirstOrDefault();


                return loginTeste;

            });

           return moqResult;

        }

        public static Mock<IUsuarioRepository> GetUserRepository()
        {

            var listaMoq = Usuario.GetMoq();


            var moqResult = new Mock<IUsuarioRepository>();


            moqResult.Setup(r => r.Add(It.IsAny<Usuario>())).ReturnsAsync((Usuario user) => {

                listaMoq = listaMoq;
                listaMoq.Add(user);

                var userlocal = listaMoq.Where(r => r.Id == user.Id).FirstOrDefault();
            
                 return userlocal;
            
               });

            return moqResult;

        }

        
    }
}
