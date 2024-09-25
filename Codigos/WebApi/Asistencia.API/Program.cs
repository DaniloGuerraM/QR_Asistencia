using Asistencia.Application;
using Asistencia.Application.Interfaces;
using Asistencia.Infrastructure.Data;
using Asistencia.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectioString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IAlumnoServicio, AlumnoServicio>();
builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();

builder.Services.AddScoped<IAsistenciaServicio, AsistenciaServicio>();
builder.Services.AddScoped<IAsistenciaRepository, RegistroAsistenciaRepository>();

builder.Services.AddScoped<IControlQRServicio, ControlQRServicio>();
builder.Services.AddScoped<IControlQRRepository, ControlQRRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectioString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
