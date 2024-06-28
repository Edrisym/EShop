using Catalog.Api.Models.Products;
using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation))
            return;

        // Marten UPSERT will cater for existing records
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
    {
        new Product()
        {
            Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "آیفون X",
            Description =
                "این گوشی بزرگترین تغییر شرکت در گوشی هوشمند پرچمدار خود در سال‌های اخیر است. شامل یک حاشیه‌ی بدون مرز است.",
            ImageFile = "product-1.png",
            Price = 950.00M,
            Category = new List<string> { "گوشی هوشمند" }
        },
        new Product()
        {
            Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
            Name = "سامسونگ 10",
            Description =
                "این گوشی بزرگترین تغییر شرکت در گوشی هوشمند پرچمدار خود در سال‌های اخیر است. شامل یک حاشیه‌ی بدون مرز است.",
            ImageFile = "product-2.png",
            Price = 840.00M,
            Category = new List<string> { "گوشی هوشمند" }
        },
        new Product()
        {
            Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
            Name = "هوآوی پلاس",
            Description =
                "این گوشی بزرگترین تغییر شرکت در گوشی هوشمند پرچمدار خود در سال‌های اخیر است. شامل یک حاشیه‌ی بدون مرز است.",
            ImageFile = "product-3.png",
            Price = 650.00M,
            Category = new List<string> { "لوازم خانگی" }
        },
        new Product()
        {
            Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
            Name = "شیائومی می 9",
            Description =
                "این گوشی بزرگترین تغییر شرکت در گوشی هوشمند پرچمدار خود در سال‌های اخیر است. شامل یک حاشیه‌ی بدون مرز است.",
            ImageFile = "product-4.png",
            Price = 470.00M,
            Category = new List<string> { "لوازم خانگی" }
        },
        new Product()
        {
            Id = new Guid("b786103d-c621-4f5a-b498-23452610f88c"),
            Name = "اچ‌تی‌سی U11+ Plus",
            Description =
                "این گوشی بزرگترین تغییر شرکت در گوشی هوشمند پرچمدار خود در سال‌های اخیر است. شامل یک حاشیه‌ی بدون مرز است.",
            ImageFile = "product-5.png",
            Price = 380.00M,
            Category = new List<string> { "گوشی هوشمند" }
        },
        new Product()
        {
            Id = new Guid("c4bbc4a2-4555-45d8-97cc-2a99b2167bff"),
            Name = "ال‌جی G7 ThinQ",
            Description =
                "این گوشی بزرگترین تغییر شرکت در گوشی هوشمند پرچمدار خود در سال‌های اخیر است. شامل یک حاشیه‌ی بدون مرز است.",
            ImageFile = "product-6.png",
            Price = 240.00M,
            Category = new List<string> { "آشپزخانه خانگی" }
        },
        new Product()
        {
            Id = new Guid("93170c85-7795-489c-8e8f-7dcf3b4f4188"),
            Name = "پاناسونیک لومیکس",
            Description =
                "این گوشی بزرگترین تغییر شرکت در گوشی هوشمند پرچمدار خود در سال‌های اخیر است. شامل یک حاشیه‌ی بدون مرز است.",
            ImageFile = "product-6.png",
            Price = 240.00M,
            Category = new List<string> { "دوربین" }
        }
    };
}