using Confluent.Kafka;
using MarketPlace.API.Kafka;
using MarketPlace.API.Services;
using MarketPlace.Application.Commands;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Infrastructure.Persistence;
using MarketPlace.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AddProductCommand).Assembly);
            });
            
            builder.Services.AddHostedService<OutboxPublisherService>();
            builder.Services.AddSingleton<IKafkaProducer>(sp =>
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = "localhost:9092"
                };
                return new KafkaProducer(config);
            });

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddDbContext<DataContext>(options => options
                .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                .UseLowerCaseNamingConvention()
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
