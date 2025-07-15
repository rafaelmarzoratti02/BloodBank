using BloodBank.Services.Donors.Application;
using BloodBank.Services.Donors.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddProblemDetails();
builder.Services.AddMemoryCache();

builder.Services
    .AddMongo()
    .AddRepositories()
    .AddValidators()
    .AddHandlers();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
    
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder
            .WithOrigins("http://localhost:3000") 
            .AllowAnyMethod()
            .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowReactApp");
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();