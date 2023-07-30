

using security.api.Application;
using security.jwt.settings;
using System.Net.NetworkInformation;
using System.Reflection;



#region Módulos
var builder = WebApplication.CreateBuilder(args);
{ 

    builder.RegisterModules();

    var services = builder.Services;

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddAuthentication(x=> {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(opt => {

        opt.RequireHttpsMetadata = false;
        opt.SaveToken = true;
        opt.TokenValidationParameters = new()
        {        
            ValidateIssuer = false,
            ValidateAudience = false,
            //ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            //   ValidIssuer = Settings.Issuer,
            //ValidAudience = builder.Configuration["Jwt:Issuer"],
            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

            //ValidateIssuer = true,
            //ValidAudiences = new List<string>
            //{
            //    "AUDIENCE1",
            //    "AUDIENCE2"
            //},


            IssuerSigningKey = new SymmetricSecurityKey(Settings.getKey())

        };

        

    });

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthenticateUserRequest).Assembly));
    



    //services.AddMediatR(typeof(AuthenticateUserRequest).GetTypeInfo().Assembly);
    //services.AddMediatR(typeof(AddUserRequest).GetTypeInfo().Assembly);

    services.AddAuthorization(opt => {

        opt.AddPolicy("Super", policy => {
            policy.RequireRole("admin");
            policy.RequireRole("professor");
            policy.RequireRole("aluno");
        });
        opt.AddPolicy("Admin", policy => policy.RequireRole("admin"));
        opt.AddPolicy("Professor", policy => policy.RequireRole("professor"));
        opt.AddPolicy("Aluno", policy => policy.RequireRole("professor"));

    });

}
#endregion


#region Servicos
//servicos
await using var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();

app.MapEndpoints();

app.UseSwaggerUI();


//executa api
await app.RunAsync();
#endregion










