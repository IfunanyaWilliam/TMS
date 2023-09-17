using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TMS.Application.Repository;
using TMS.Infrastructure.DbContext;
using TMS.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add the DbContext to the builder
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


//IMediatRHandler interface is used to mark all Handlers as a MediatR type
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IMediatRHandler).Assembly));


builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IAppTaskRepository, AppTaskRepository>();

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
