using AvaliacaoFC.Nucleo;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Contexto>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("AvaliacaoFC"))
    );

builder.Services.AdicionarNucleo(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
