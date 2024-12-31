using hospital.Data;
using hospital.Models;
using hospital.Repo.AppointmentRepo;
using hospital.Repo.DoctorRepo;
using hospital.Repo.PatientRepo;
using hospital.Repo.PrescriptionsRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<Appdbcontext>(s => s.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDoctor, DoctorR>();
builder.Services.AddScoped<IPrescription, PrescriptionsR>();
builder.Services.AddScoped<IAppointment, AppointmentR>();
builder.Services.AddScoped<IPatient, PatientR>();
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
