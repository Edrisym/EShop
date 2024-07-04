namespace Basket.Api.Models;

public class ShoppingCart
{
    public string UserName { get; set; } = default!;

    public decimal TotalPrice => ShoppingCartItems.Sum(x => x.Price * x.Quantity);
    private List<ShoppingCartItem> Items { get; set; } = default!;

    public IReadOnlyCollection<ShoppingCartItem> ShoppingCartItems
        => Items;

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }
    
    //For mapping tables
    public ShoppingCart()
    {
        
    }
}