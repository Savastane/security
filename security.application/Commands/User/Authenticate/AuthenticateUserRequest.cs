﻿


namespace security.application
{
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class AuthenticateUserRequest : IRequest<AuthenticateUserResponse>
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
        

        public AuthenticateUserRequest(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        
        }

    }
}
