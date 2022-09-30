using AppRequests.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRequests.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };

    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = await context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();

        if (category == null)
        {
            return Results.NotFound();
        }

        category.Name = categoryRequest.Name;
        category.Active = categoryRequest.Active;

        await context.SaveChangesAsync();
        return Results.Ok();
    }
}

