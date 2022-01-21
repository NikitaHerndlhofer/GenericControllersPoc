using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MinimalGenericApi.DataAccess;
using MinimalGenericApi.DataAccess.Abstractions;
using MinimalGenericApi.GenericControllers;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(InMemoryGenericRepository<>));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("V1", new OpenApiInfo()
    {
        Title = "SimpleGenericApi",
        Version = "V1",
    });
});

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

var types = builder.Services.BuildGenericControllers(typeof(IEntity), typeof(IEntity));

builder.Services.AddMvc()
    .ConfigureApplicationPartManager(apm =>
        apm.ApplicationParts.Add(new GenericControllerApplicationPart(types)));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("swagger/v1/swagger.json", "SimpleGenericApi v1"));
app.UseHttpsRedirection();
app.MapControllers();
app.Run();