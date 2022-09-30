using AppRequests.Domain.Products;
using AppRequests.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace AppRequests.Endpoints.Products;

public class ProductPost
{

    public static string Template => "/products";
    public static string[] Methods => new string[] {HttpMethods.Post.ToString()};
    public static Delegate Handle => Action;

    public static async Task<IResult> Action (ProductRequest productsRequest, ApplicationDbContext context)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == productsRequest.CategoryId);
        var product = new Product(productsRequest.Name, productsRequest.Code, category, productsRequest.Description, productsRequest.HasStock);

        if (!product.IsValid)
        {
            return Results.BadRequest();
        }

        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        return Results.Created($"/Products /{product.Id}", product.Id);
    }
}
