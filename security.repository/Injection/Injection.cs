





namespace security.injection
{
    
    using Microsoft.Extensions.DependencyInjection;
    using security.domain;
    using security.repository;


    public static class Injection
    {
        public static IServiceCollection Addinfrastructure(this IServiceCollection services)
        {
            services.AddRavenDbDocStore() // 1. Configures Raven connection using the settings in appsettings.json.
                    .AddRavenDbAsyncSession(); // 2. Add a scoped IAsyncDocumentSession. For the sync version, use .AddRavenSession() instead.

                        
            services.AddScoped<IUsuarioRepository, UserRepository>();

            return services;
        }
    }





}

