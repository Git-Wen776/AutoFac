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
using AutoFac.Extentions.AutoMapperConfig;
using NLog.Web;
using NLog.Extensions.Logging;
using AutoFac.Extentions.NLogger;
using Quartz;
using GZY.Quartz.MUI.Extensions;
using Microsoft.Extensions.Caching.StackExchangeRedis;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
builder.Services.AddLogging(p => {
    p.AddConsole();
    p.AddNLog();
});

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
builder.Services.AddStackExchangeRedisCache(p =>
{
    Console.WriteLine(config.GetSection("RedisConnect:conncetStr").Value);
    p.Configuration = "82.157.50.112:1545";
    p.InstanceName = "Aw";
});
builder.Services.AddAutoMapperSetup();
builder.Services.AddLoggerSetup();
#region quartzÒÔ¼°quartz uiÅäÖÃ
builder.Services.AddQuartz(p=> { });
builder.Services.AddQuartzServer(p => {
   
});
builder.Services.AddQuartzUI();
#endregion
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
app.UseRouting();
//app.UseQuartz();

app.UseAuthorization();

app.MapControllers();

app.Run();
