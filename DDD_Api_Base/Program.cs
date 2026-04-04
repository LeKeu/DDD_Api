using Common.Domain.ValueObjects;
using Evento.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


var teste = Customer.CreateCustomer(
    new CustomerConstructorProp() { Cpf = new CpfVO("12345678909"), Nome = new NomeVO("Letícia")});

Console.WriteLine(teste.Cpf);
Console.WriteLine(teste.Nome);