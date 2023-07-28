
namespace security.test.Application
{
    using security.api.Application;
    
    using System.Collections.Generic;
    using System.Threading;
    using Xunit;

    public class UserTest
    {
        [Fact]
        public void AddUserOKTest()
        {
            
            
            var resultado = MockAutentircarRepository.GetUserRepository();

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


        [Fact]
        public void GetUserOKTest()
        {


            var resultado = MockAutentircarRepository.GetUserRepository();

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


        [Fact]
        public void UpdateUserOKTest()
        {


            var resultado = MockAutentircarRepository.GetUserRepository();

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


        [Fact]
        public void RemoveUserOKTest()
        {


            var resultado = MockAutentircarRepository.GetUserRepository();

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

