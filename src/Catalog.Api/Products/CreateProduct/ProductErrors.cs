using System.Runtime.InteropServices.JavaScript;
using BuildingBlocks.Common.Response;

namespace Catalog.Api.Products.CreateProduct;

public static class ProductErrors
{
  public static Error InvalidProductName => new("ProductErrors.InvalidProductNameError","نام وارد شده برای محصول معتبر نیست.");
  public static Error DuplicatedProductError => new("ProductErrors.DuplicatedProductError","محصول وارد شده تکراری است.");
  public static Error InvalidDescriptionError => new("ProductErrors.InvalidDescriptionError", "توضیحات محصول معتبر نیست.");
  public static Error PriceIsNegativeError => new("ProductErrors.PriceIsNegativeError", "قیمت محصول نمی تواند کمتر از صفر باشد.");
  public static Error EmptyCategoryError => new("ProductErrors.PriceIsNegativeError", "دستهبندی ها نمی تواند خالی باشد.");
  public static Error ProductNotFoundError => new("ProductErrors.ProductErrors.ProductNotFoundError", "محصول مورد نظر پیدا نشد.");

}