namespace security.controller
{
        
    
    using security.injection;
    using security.jwt.token;
    using security.application;
    using security.jwt.settings;


    using System.Reflection;

    public  class SystemController : IModule
    {
        public  IServiceCollection RegisterModule( IServiceCollection services)
        {   
            return services.Addinfrastructure();

        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, WebApplicationBuilder builder)
        {

            endpoints.MapGet("system/v1/database/fill",  async (HttpContext http, IMediator mediator) =>
            {                
               var result = await mediator.Send(new FillDatabaseRequest());
                return Results.Ok(result);

            }).AllowAnonymous(); 

            

            return endpoints;
        }

    }


}
