using MarketPlace.Domain.Events.Interface;
using MarketPlace.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MarketPlace.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options): base(options) { }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<ShopEntity> Shops { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEstimationEntity> ProductEstimations { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEntities = ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(x => x.Entity.DomainEvents.Any())
            .ToList();

        List<IDomainEvent> domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            OutboxMessage outboxMessage = new OutboxMessage
            {
                Id = Guid.NewGuid(),
                Type = domainEvent.GetType().Name,
                Payload = JsonConvert.SerializeObject(domainEvent),
                OccurredOn = domainEvent.OccurredOn,
                IsProcessed = false,
            };
            await OutboxMessages.AddAsync(outboxMessage, cancellationToken);
        }

        domainEntities.ForEach(d => d.Entity.ClearDomainEvents());
        return await base.SaveChangesAsync(cancellationToken);
    }
}