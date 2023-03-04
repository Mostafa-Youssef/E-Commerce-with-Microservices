using EventBus.Messages.Common;
using Mapster;
using MapsterMapper;
using MassTransit;
using Ordering.API.EventBusConsumer;
using Ordering.API.Extensions;
using Ordering.API.Middleware;
using Ordering.API.RabbitMQ;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddScoped<BasketCheckoutConsumer>();

#region MassTransit-RabbitMQ Configuration

RabbitMQOption rabbitMQOption = new RabbitMQOption();
builder.Configuration.GetSection(nameof(RabbitMQOption)).Bind(rabbitMQOption);

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BasketCheckoutConsumer>();

    config.UsingRabbitMq((context, cfg) =>
    {
        //cfg.Host("amqp://guest:guest@localhost:5672");
        cfg.Host(rabbitMQOption.Host, config =>
        {
            config.Username(rabbitMQOption.UserName);
            config.Password(rabbitMQOption.Password);
        });

        cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
        {
            c.ConfigureConsumer<BasketCheckoutConsumer>(context);
        });
    });
});

#endregion

#region Mapping Dependency

var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MigrateDatabaseAsync<AppContextSeed>().Wait();

app.Run();

