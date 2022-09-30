using AppRequests.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace AppRequests.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    public static async Task<IResult> Action(ApplicationDbContext context)
    {
        var categories = await context.Categories.ToListAsync();
         var response = categories.Select(categories => new CategoryResponse { Id = categories.Id, Name = categories.Name, Active = categories.Active });
        return Results.Ok(response);
    }
}

