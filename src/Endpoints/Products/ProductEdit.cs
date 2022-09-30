using AppRequests.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRequests.Endpoints.Products;

public class ProductEdit
{
    public static string Template => "/products/{code}";
    public static string[] Methods => new string[] { HttpMethods.Put.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] string code, ProductRequest productRequest, ApplicationDbContext context)
    {
        var productSaved = await context.Products.FirstOrDefaultAsync(p => p.Code == code);

        if (productSaved == null)
        {
            return Results.NotFound();
        }

        productSaved.Name = productRequest.Name;
        productSaved.Code = productRequest.Code;
        productSaved.Description = productRequest.Description;
        productSaved.CategoryId = productRequest.CategoryId;
        productSaved.HasStock = productRequest.HasStock;

        await context.SaveChangesAsync();

        return Results.Ok();
    }
}
