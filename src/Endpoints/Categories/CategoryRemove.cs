using AppRequests.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRequests.Endpoints.Categories;

public class CategoryRemove
{
    public static string Template => "/categories/{name}";
    public static string[] Methods => new string[] { HttpMethods.Delete.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] string name, ApplicationDbContext context)
    {
        var categorySaved = await context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        context.Categories.Remove(categorySaved);
        await context.SaveChangesAsync();

        return Results.Ok();
    }
}
