using MedicationAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

try
{
    var cnx = new Npgsql.NpgsqlConnection(builder.Configuration.GetConnectionString("Medication"));
    var evolve = new EvolveDb.Evolve(cnx)
    {
        Locations = new[] { "Evolve/Migrations" },
    };

    evolve.Migrate();
}
catch (Exception ex)
{
    throw;
}

builder.Services.AddDbContext<MedicationAPI.Repo.DataModels.MedicationDataModels.MedicationAPIDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Medication")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddScoped<MedicationAPI.Repo.Interfaces.IMedication, MedicationAPI.Repo.Repos.Medication>();

builder.Services.AddScoped<MedicationApi.Business.Interfaces.IMedication, MedicationAPI.Business.Medication>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();