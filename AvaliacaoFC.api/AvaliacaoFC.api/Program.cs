using AvaliacaoFC.Nucleo;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Contexto>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("AvaliacaoFC"))
    );

builder.Services.AdicionarNucleo(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

CultureInfo culturaBrasileira = new("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = culturaBrasileira;
CultureInfo.DefaultThreadCurrentUICulture = culturaBrasileira;
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
