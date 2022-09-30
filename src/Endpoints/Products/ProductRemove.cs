using AppRequests.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRequests.Endpoints.Products;

public class ProductRemove
{
    public static string Template => "/products/{code}";
    public static string[] Methods => new string[] { HttpMethods.Delete.ToString()};
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] string code, ApplicationDbContext context)
    {
        var productSaved = await context.Products.FirstOrDefaultAsync(p => p.Code == code);
        context.Products.Remove(productSaved);
        await context.SaveChangesAsync();
        return Results.Ok(productSaved);
    }
}
