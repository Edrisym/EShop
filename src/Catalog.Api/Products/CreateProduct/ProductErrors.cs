using BuildingBlocks.Common.Response;

namespace Catalog.Api.Products.CreateProduct;

public class ProductErrors
{
  public static Error InvalidProductName => new("InvalidProductName","نام وارد شده برای محصول معتبر نیست.");
}