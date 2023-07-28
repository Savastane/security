namespace security.api.Application
{
    using MediatR;
    

    public class AuthenticateUserRequest : IRequest<AuthenticateUserResponse>
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }


        public AuthenticateUserRequest(string email, string password)
        {
            Email = email;
            Password = password;

        }

    }
}
