using BookInn.Api.Extensions;
using BookInn.Application;
using BookInn.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.ApplyMigrations();
   // app.SeedData();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();