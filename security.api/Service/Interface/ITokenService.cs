using security.api.Application;
using security.domain;

namespace security.api.Service.Interface
{
    public interface ITokenService
    {
        void BuildToken(byte[] Secrett, string issuer, AuthenticateUserResponse user);

        AuthenticateUserResponse Generate(AuthenticateUserResponse user);

    }
}
