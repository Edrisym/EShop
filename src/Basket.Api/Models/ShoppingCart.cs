namespace Basket.Api.Models;

public class ShoppingCart
{
    public string UserName { get; set; } = default!;
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    public List<ShoppingCartItem> Items { get; set; } = [];
    // public IReadOnlyCollection<ShoppingCartItem> ShoppingCartItems => Items;

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }

    //For mapping tables
    public ShoppingCart()
    {
    }
}