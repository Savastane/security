namespace security.api.Service
{
    using security.api.Application;
    using security.api.Service.Interface;
    using security.domain;
    using security.jwt.settings;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;



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

        
        public AuthenticateUserResponse Generate(AuthenticateUserResponse usuario)
        {


            var response = usuario;

            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(response),
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = credentials,
            };

            var token = handler.CreateToken(tokenDescriptor);




            response.Token= handler.WriteToken(token);

            return response;


        }


        private static ClaimsIdentity GenerateClaims(AuthenticateUserResponse user)
        {
            var claims = new ClaimsIdentity();



            claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));


            foreach (var role in user.Roles)
            {
                var claim = new Claim(ClaimTypes.Role, role);
                claims.AddClaim(claim);
            }
                


            return claims;
        }

    }


}
