
using security.jwt.settings;



#region Módulos
var builder = WebApplication.CreateBuilder(args);

builder.RegisterModules();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(x=> {
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
        ValidAudiences = new List<string>
        {
            "AUDIENCE1",
            "AUDIENCE2"
        },


        IssuerSigningKey = new SymmetricSecurityKey(Settings.getKey())

    };

});

builder.Services.AddAuthorization(opt => {

    opt.AddPolicy("Super", policy => {
        policy.RequireRole("admin");
        policy.RequireRole("professor");
        policy.RequireRole("aluno");
    });
    opt.AddPolicy("Admin", policy => policy.RequireRole("admin"));
    opt.AddPolicy("Professor", policy => policy.RequireRole("professor"));
    opt.AddPolicy("Aluno", policy => policy.RequireRole("professor"));

});

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










