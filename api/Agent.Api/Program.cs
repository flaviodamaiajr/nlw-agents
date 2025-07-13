using Agent.Api.Middlewares;
using Agent.Application.Interfaces;
using Agent.Application.Services;
using Agent.Domain.Interfaces;
using Agent.Infra;
using Agent.Infra.Persistence.Repositories;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddFastEndpoints();

// Register Services
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomQuestionService, RoomQuestionService>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomQuestionRepository, RoomQuestionRepository>();

builder.Services.AddDbContext<AgentDbContext>(options =>
    options.UseInMemoryDatabase("AppDb"));

var app = builder.Build();

app.UseFastEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.Run();
