using MarketPlace.API.Kafka.Consumer;
using MarketPlace.API.Kafka.Producer;
using MarketPlace.API.Services;
using MarketPlace.Application.Commands.Products;
using MarketPlace.Application.Commands.Shops;
using MarketPlace.Application.Commands.Users;
using MarketPlace.Domain.Events;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Infrastructure.Persistence;
using MarketPlace.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen();

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(AddProductCommand).Assembly, 
                typeof(AddShopCommand).Assembly, 
                typeof(AddUserCommand).Assembly
            );
        });
        
        //builder.Services.AddHostedService<OutboxPublisherService>();
        //builder.Services.AddSingleton<IKafkaProducer>(sp =>
        //{
        //    return new KafkaProducer(builder.Configuration);
        //});

        //builder.Services.AddHostedService<KafkaBackgroundConsumer<ProductAddedEvent>>();
        //builder.Services.AddScoped<IKafkaConsumer<ProductAddedEvent>, ProductAddedConsumer>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IShopRepository, ShopRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddDbContext<DataContext>(options => options
            .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            .UseLowerCaseNamingConvention()
        );

        var app = builder.Build();

        app.UseCors("AllowFrontend");

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
