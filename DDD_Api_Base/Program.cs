using Common.Domain.ValueObjects.Customer;
using Evento.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

