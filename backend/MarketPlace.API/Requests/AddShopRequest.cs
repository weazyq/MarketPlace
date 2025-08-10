namespace MarketPlace.API.Requests
{
    public class AddShopRequest
    {
        public required String Name { get; set; }
        public required String JuridicalName { get; set; }
        public required String Description { get; set; }
    }
}
