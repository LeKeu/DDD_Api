using Common.Domain.ValueObjects;
using Evento.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

var customer1 = Customer.CreateCustomer(
    new CustomerConstructorProp() { Cpf = new CpfVO("12345678909"), Nome = new NomeVO("Letícia")});

Console.WriteLine(customer1.Cpf);
Console.WriteLine(customer1.Nome);
customer1.Nome = new NomeVO("malu");
Console.WriteLine(customer1.Nome);

var customer2 = Customer.CreateCustomer(
    new CustomerConstructorProp() { Cpf = new CpfVO("12345678909"), Nome = new NomeVO("Malu"), Id = new UuidVO(customer1.Id.ToString()) });

var customer3 = new Customer(new CustomerConstructorProp() { Cpf = new CpfVO("12345678909"), Nome = new NomeVO("Malu"), Id = new UuidVO(customer1.Id.ToString()) });

Console.WriteLine(customer1.Equals(customer3));

app.Run();

