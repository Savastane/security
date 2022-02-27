
namespace security.test.Application
{

using security.application;
using security.domain;
    using System.Collections.Generic;
    using System.Threading;
using Xunit;

    public class UserTest
    {
        [Fact]
        public void AddUserOKTest()
        {
            
            
            var resultado = MockAutentircarRepository.AddUserRepository();

            var handler = new AddUserHandler(resultado.Object);

            var roles = new List<string>();
            roles.Add("admin");

            var requestModel = new AddUserRequest("sava", "sava@organizer.one", "12345", roles);
            
            var userResult = handler.Handle(requestModel, CancellationToken.None).Result;

            Assert.True(userResult.Email == userResult.Id);
            Assert.True(requestModel.Email == userResult.Id);
            Assert.True(requestModel.Roles[0] == userResult.Roles[0]);
            Assert.True(userResult.Roles[0].Equals("admin"));

        }
       


    }
}

