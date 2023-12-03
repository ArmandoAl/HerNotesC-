using Microsoft.EntityFrameworkCore;
using Data;
using Data.Contracts;
using Business.Contracts;
using Business.Implementation;
using Data.Implementation;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SurveyDBContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();
builder.Services.AddScoped<INotaService, NotaService>();
builder.Services.AddScoped<INotaRepository, NotaRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IEmocionService, EmocionService>();
builder.Services.AddScoped<IEmocionRepository, EmocionRepository>();
builder.Services.AddScoped<IGrupoRepository, GrupoRepository>();
builder.Services.AddScoped<IGrupoService, GrupoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});


app.MapControllers();

app.Run();
