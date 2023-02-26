// See https://aka.ms/new-console-template for more information
using Authentication.Backend.Infrastructure.Data.Contexts;

Console.WriteLine("Create data base");
BackendContext appContext = new BackendContext();
appContext.Database.EnsureCreated();
Console.WriteLine("OK");
