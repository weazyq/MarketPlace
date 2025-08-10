
namespace MarketPlace.Domain.Shops
{
    public class Shop
    {
        public Guid Id { get; }
        public String Name { get; }
        public String JuridicalName { get; }
        public String Description { get; }

        public Shop(Guid id, string name, string juridicalName, string description)
        {
            Id = id;
            Name = name;
            JuridicalName = juridicalName;
            Description = description;
        }
    }
}
