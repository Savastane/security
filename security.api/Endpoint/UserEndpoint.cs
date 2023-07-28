namespace security.controller
{


    using security.injection;
    using security.jwt.settings;


    using System.Reflection;
    using security.api.Service;
    using security.api.Service.Interface;    
    using security.api.Application;

    public  class UserEndpoint: IModule
    {
        public  IServiceCollection RegisterModule( IServiceCollection services)
        {
            services.AddSingleton<ITokenService>(new TokenService());            

            return services.Addinfrastructure();

        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, WebApplicationBuilder builder)
        {
            /// 
            ///  Autentticar
            /// 
            endpoints.MapPost("user/v1/authenticate", [AllowAnonymous] async (HttpContext http, IMediator mediator, AuthenticateUserRequest request) =>
            {
                var result = await mediator.Send(request);

                if (result.Notifications.Count > 0)                
                    return Results.BadRequest(result.Notifications);               

                if (result.EmailNaoEncontrado)                
                    return Results.NotFound(new { message = "login inválido" });                

                if (result.PasswordInvalido)                
                    return Results.NotFound(new { message = "Senha inválida" });                

                return Results.Ok(result);

            });

            /// 
            ///  Resgatar a senha
            /// 
            endpoints.MapPost("user/v1/password/recover",  (ClaimsPrincipal usuario) =>
            {
                var lista = usuario.Claims.ToList();

                return Results.Ok(lista);

            }).AllowAnonymous();


            endpoints.MapPost("user/v1/add", [AllowAnonymous] async (HttpContext http, IMediator mediator, ITokenService tokenService,AddUserRequest request )  =>
            {
                request.Audiencia = "organizer.one";
                var result = await mediator.Send(request);                
                return Results.Ok(result);

            });


            //endpoints.MapPut("user/v1/update", (ClaimsPrincipal usuario) =>
            //{
            //    var lista = usuario.Claims.ToList();

            //    return Results.Ok(lista);

            //}).RequireAuthorization("System");


            //endpoints.MapDelete("user/v1/remove", (ClaimsPrincipal usuario) =>
            //{
            //    var lista = usuario.Claims.ToList();

            //    return Results.Ok(lista);

            //}).RequireAuthorization("System");

            //endpoints.MapGet("user/v1/list+", (ClaimsPrincipal usuario) =>
            //{
            //    var lista = usuario.Claims.ToList();

            //    return Results.Ok(lista);

            //}).RequireAuthorization("System");



            endpoints.MapPost("/v1/anonimo", (ClaimsPrincipal usuario) => {


                return Results.Ok(usuario.Identity.Name);

            }).RequireAuthorization("Super");

            return endpoints;
        }

    }


}
