namespace security.controller
{
        
    
    using security.injection;        

    using security.api.Application;

    public  class SystemEndPoint : IModule
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
