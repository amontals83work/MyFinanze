using Microsoft.EntityFrameworkCore;
using MyFinanzeAPI.Data; // Cambia el namespace seg�n corresponda a tu proyecto

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios para el contenedor
builder.Services.AddControllers(); // A�adir soporte para controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el DbContext para la base de datos (ajusta el string de conexi�n cuando lo necesites)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Construir la aplicaci�n
var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

app.Run();
