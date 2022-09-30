using AppRequests.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRequests.Endpoints.Products;

public class ProductGetCode
{
    public static string Template => "/products/{Code}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] string code, ApplicationDbContext context)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Code == code);
        return Results.Ok(product);
    }
}
