using Api.Extensions;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Configurar servicios
builder.Services.AddControllers();
// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Configurar CORS para permitir todos los orígenes
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP

app.UseSwagger();
app.UseSwaggerUI();


app.ApplyMigration();
//app.SeedData();
app.UseCustomExceptionHandler();

// Usar el middleware de CORS
app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
