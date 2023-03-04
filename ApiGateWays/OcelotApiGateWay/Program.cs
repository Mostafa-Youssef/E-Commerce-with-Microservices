using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Logging.AddJsonConsole();

builder.Services.AddOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();

app.UseOcelot().Wait();