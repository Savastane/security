
namespace security.test.Application
{

using security.application;
using security.domain;
using System.Threading;
using Xunit;

    public class LoginTest
    {

        [Fact]
        public void LoginValidoTest()
        {
            MockAutentircarRepository.Inicializar("savastane@gmail.com", "12345");

            //MockAutentircarRepository.loginAutenticacao = new Login("savastane@gmail.com", "12345","");
            var resultado = MockAutentircarRepository.getLoginRepository();


            //injecao repostiorio
            var handler = new AuthenticateUserHandler(resultado.Object);

            //chama comando
            var result = handler.Handle(new AuthenticateUserRequest(MockAutentircarRepository.userAuthenticate.Email.Endereco
                , MockAutentircarRepository.userAuthenticate.Password), CancellationToken.None);

            
            //valida
            Assert.False(result.Result.EmailNaoEncontrado);
            Assert.False(result.Result.PasswordInvalido);
            

        }
      
        [Fact]
        public void LoginInvalidoTest()
        {
            MockAutentircarRepository.userAuthenticate = new Usuario("savastane@gmail.com1", "12345");
            var resultado = MockAutentircarRepository.getLoginRepository();
            var handler = new AuthenticateUserHandler(resultado.Object);


            var result = handler.Handle(new AuthenticateUserRequest(MockAutentircarRepository.userAuthenticate.Email.Endereco
                , MockAutentircarRepository.userAuthenticate.Password), CancellationToken.None);


            //valida
            Assert.True(result.Result.EmailNaoEncontrado);
            

        }

        [Fact]
        public void EmailOkSenhaInvalidaTest()
        {
            MockAutentircarRepository.userAuthenticate = new Usuario("savastane@gmail.com", "123451");
            var resultado = MockAutentircarRepository.getLoginRepository();
            var handler = new AuthenticateUserHandler(resultado.Object);


            var result = handler.Handle(new AuthenticateUserRequest(MockAutentircarRepository.userAuthenticate.Email.Endereco
                , MockAutentircarRepository.userAuthenticate.Password), CancellationToken.None);


            Assert.True(result.Result.PasswordInvalido);
            

        }


    }
}
