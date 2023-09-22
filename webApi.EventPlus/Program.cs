using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Aciona o serviço de JWT Bearer ( forma de autenticação )

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem está solicitando
        ValidateIssuer = true,

        // Valida quem está recebendo
        ValidateActor = true,

        // Define se o tempo de expiração sera validado
        ValidateLifetime = true,

        // Forma de criptografia e valida a chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key-eventplus.webapi.auth.dev-senai")),

        // Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        // Nome do issuer (de onde está vindo)
        ValidIssuer = "Event",

        // Nome da audience (para onde está indo)
        ValidAudience = "Event"
    };
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Adicione o gerador do Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informações sobre a API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Event+ WEBAPI",
        Description = "Uma API criada no SENAISP para realização do projeto EventPlus, projeto de avaliação da sprint 2 API.",
        Contact = new OpenApiContact
        {
            Name = "Github",
            Url = new Uri("https://github.com/wenderdecastro")
        },

    });

    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
