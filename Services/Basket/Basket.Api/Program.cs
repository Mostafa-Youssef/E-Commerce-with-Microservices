using Basket.Api.GrpcService;
using Basket.Api.Options;
using Basket.Api.Repositories;
using Discount.Grpc.Protos;
using Mapster;
using MapsterMapper;
using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["CacheSettings:ConnectionString"];
});
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<DiscountGrpcService>();
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
                (x => x.Address = new Uri(builder?.Configuration["GrpcSettings:DiscountUrl"]));

#region MassTransit-RabbitMQ Configuration

RabbitMQOption rabbitMQOption = new RabbitMQOption();
builder.Configuration.GetSection(nameof(RabbitMQOption)).Bind(rabbitMQOption);

builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((context, cfg) =>
    {
        //cfg.Host("amqp://guest:guest@localhost:5672");
        cfg.Host(rabbitMQOption.Host, config =>
        {
            config.Username(rabbitMQOption.UserName);
            config.Password(rabbitMQOption.Password);
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

app.Run();
