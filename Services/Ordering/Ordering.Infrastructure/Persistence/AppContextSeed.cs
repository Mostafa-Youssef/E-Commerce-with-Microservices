using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using Ordering.Domain.Entities.EntityHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class AppContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILogger<AppContextSeed> logger)
        {
            if (!context.DeliveryMethods.Any())
            {
                await context.DeliveryMethods.AddRangeAsync(GetDeliveryMethods());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(AppDbContext).Name);


                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                ////var dmData = File.ReadAllText("../Ordering.Infrastructure/Persistence/SeedData/delivery.json");
                //////var path = Path.Combine(Directory.GetCurrentDirectory(), $"\\Persistence\\SeedData\\delivery.json");
                //var dmData = File.ReadAllText(path + @"/Persistence/SeedData/delivery.json");

                //var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                //foreach (var item in methods)
                //{
                //    context.DeliveryMethods.Add(item);
                //}
                //await context.SaveChangesAsync();
            }
            if (!context.orders.Any())
            {
                await context.orders.AddRangeAsync(GetPreconfiguredOrders());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(AppDbContext).Name);
            }

            
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    UserName = "swn",
                    TotalPrice = 350,
                    DeliveryMethodId = 1,
                    Status = OrderStatus.Pending,
                    Address = new Address
                    {
                        FirstName = "Mostafa",
                        LastName = "Youssef",
                        EmailAddress = "most@gmail.com",
                        AddressLine = "15may",
                        Country = "Egypt"
                    }
                }
            };
        }

        private static IEnumerable<DeliveryMethod> GetDeliveryMethods()
        {
            var ccc =  new List<DeliveryMethod>
            {
                new DeliveryMethod()
                {
                    //Id = 1,
                    ShortName = "UPS1",
                    Description = "Fastest delivery time",
                    DeliveryTime = "1-2 Days",
                    Price = 10
                },
                new DeliveryMethod()
                {
                    //Id = 2,
                    ShortName = "UPS2",
                    Description = "Get it within 5 days",
                    DeliveryTime = "2-5 Days",
                    Price = 5
                },
                new DeliveryMethod()
                {
                    //Id = 3,
                    ShortName = "UPS3",
                    Description = "Slower but cheap",
                    DeliveryTime = "5-10 Days",
                    Price = 2
                },
                new DeliveryMethod()
                {
                    //Id = 4,
                    ShortName = "FREE",
                    Description = "Free! You get what you pay for",
                    DeliveryTime = "1-2 Weeks",
                    Price = 0
                }
            };
            return ccc;
        }

    }
}
