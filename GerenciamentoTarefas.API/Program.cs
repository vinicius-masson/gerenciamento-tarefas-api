using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciamentoTarefas.API.Filters;
using GerenciamentoTarefas.Application.Configuration;
using GerenciamentoTarefas.Application.Services.Implementations;
using GerenciamentoTarefas.Application.Services.Interfaces;
using GerenciamentoTarefas.Application.Validations;
using GerenciamentoTarefas.Domain.Entities;
using GerenciamentoTarefas.Domain.Repositories;
using GerenciamentoTarefas.Infrastructure.Persistence;
using GerenciamentoTarefas.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
        //policy.SetIsOriginAllowed(origin => new[] { "http://localhost:3000", "https://localhost:3000" }.Contains(origin))
        //     .AllowAnyHeader()
        //     .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ConnectionString
var connectionString = builder.Configuration.GetConnectionString("GerenciamentoTarefas");
builder.Services.AddDbContext<GerenciamentoTarefasDbContext>(options => options.UseSqlServer(connectionString));

//Injeção de Depêndencia
builder.Services.AddScoped<IRepository<Tarefa>, TarefaRepository>();
builder.Services.AddScoped<ITarefaService, TarefaService>();

//Automapper
builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutomapperConfig>();
}).CreateMapper());

//Validação do ModelState
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

//Fluent Validation
builder.Services
    .AddValidatorsFromAssemblyContaining<TarefaDTOValidation>()
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
