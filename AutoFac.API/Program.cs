using AutoFac.Extentions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoFac.API;
using AutoFac.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using AutoFac.Extentions.Redis;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .Add(new JsonConfigurationSource()
    {
        Path = "appsetings.json",
        Optional = true,
        ReloadOnChange = true
    })
    .Build();
builder.Services.AddLogging(p => { 
 p.AddConsole();
 
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ITestService,TestService>();
builder.Services.AddScoped<BlogContext>(p=> new BlogContext(config.GetConnectionString("BlogDB")));
builder.Services.AddAppsettingSetup();
builder.Services.AddRediWorkSetup();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
  
});


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
