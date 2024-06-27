namespace Catalog.Api.Models.Products;

public static class PriceValidation
{
    public static bool IsGreaterThanZero(this decimal value)
    {
        return value > 0;
    }
}