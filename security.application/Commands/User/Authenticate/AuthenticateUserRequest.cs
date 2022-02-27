


namespace security.application
{
    using MediatR;

    public class AuthenticateUserRequest : IRequest<AuthenticateUserResponse>
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
        

        public AuthenticateUserRequest(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        
        }

    }
}
