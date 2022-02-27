



namespace security.module
{

    public interface IModule
    {
        IServiceCollection RegisterModule(IServiceCollection builder);
        IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, WebApplicationBuilder builder);
    }


    public static class ModuleExtensions
    {
        // this could also be added into the DI container
        static readonly List<IModule> registeredModules = new List<IModule>();

        static WebApplicationBuilder? _build   ;

        public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
        {

            _build = builder;

            var modules = DiscoverModules();
            foreach (var module in modules)
            {
                module.RegisterModule(builder.Services);
                registeredModules.Add(module);
            }

            return builder;
        }

        public static WebApplication MapEndpoints(this WebApplication app)
        {
            foreach (var module in registeredModules)
            {
                module.MapEndpoints(app, ModuleExtensions._build);
            }
            return app;
        }

        private static IEnumerable<IModule> DiscoverModules()
        {
            return typeof(IModule).Assembly
                .GetTypes()
                .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
                .Select(Activator.CreateInstance)
                .Cast<IModule>();
        }
    }
}
