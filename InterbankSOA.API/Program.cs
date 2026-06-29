using Microsoft.EntityFrameworkCore;
using InterbankSOA.API.Models;
using InterbankSOA.API.Repositories;
using InterbankSOA.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar el contexto de la base de datos
builder.Services.AddDbContext<InterbankSOAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de servicios y controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// Registro de Repositorios y Servicios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear los controladores
app.MapControllers();

app.Run();