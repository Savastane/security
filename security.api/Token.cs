namespace security.jwt.token
{
    using security.application;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    public interface ITokenService
    {
        void BuildToken(byte[] Secrett, string issuer, AuthenticateUserResponse user);

    }

    public class TokenService : ITokenService
    {
        
        public void BuildToken(byte[] secret, string issuer, AuthenticateUserResponse user)
        {
            user.Nome = user.Nome ?? "Anonimo ";

            var listaClaim = new List<Claim>();

            listaClaim.Add(new Claim(ClaimTypes.Name, user.Nome));
            listaClaim.Add(new Claim(ClaimTypes.Email, user.Email));

            if (user.Roles is not null)
            {
                foreach (var role in user.Roles)
                {
                    listaClaim.Add(new Claim(ClaimTypes.Role, role));

                }
            }
            else
            {
                listaClaim.Add(new Claim(ClaimTypes.Role, "admin"));
            }

            
            listaClaim.Add(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));

            var claims = listaClaim.ToArray();

            var securityKey = new SymmetricSecurityKey(secret);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            

            var tokenDescriptor1 = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,

            };
            var tokenHandle = new JwtSecurityTokenHandler();
            var token = tokenHandle.CreateToken(tokenDescriptor1);
            user.Token = tokenHandle.WriteToken(token);


        }
    }

    
}
