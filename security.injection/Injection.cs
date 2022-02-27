





namespace security.injection
{
    
    using MediatR;
    using System.Reflection;
    
    using Microsoft.Extensions.DependencyInjection;

    using security.application;
    using security.domain;
    using security.repository;


    public static class Injection
    {
        public static IServiceCollection Addinfrastructure(this IServiceCollection services)
        {
            services.AddRavenDbDocStore() // 1. Configures Raven connection using the settings in appsettings.json.
                    .AddRavenDbAsyncSession(); // 2. Add a scoped IAsyncDocumentSession. For the sync version, use .AddRavenSession() instead.


            
            services.AddMediatR(typeof(AuthenticateUserRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddUserRequest).GetTypeInfo().Assembly);
                        
            services.AddScoped<IUsuarioRepository, UserRepository>();



            return services;
        }
    }





}

