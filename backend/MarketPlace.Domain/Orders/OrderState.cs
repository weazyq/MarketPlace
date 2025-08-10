namespace MarketPlace.Domain.Orders;

public enum OrderState
{
    Created = 0,
    Processing = 1, 
    Way = 2,
    Canceled = 3,
    Completed = 4
}
