using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Repositories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateProjectCommand));
builder.Services.AddMediatR(typeof(GetAllSkillsQuery));

// Configure repositories
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
