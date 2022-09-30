using AppRequests.Domain.Products;
using AppRequests.Infra.Data;


namespace AppRequests.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

    public static Delegate Handle => Action;

    public static async Task<IResult> Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = new Category(categoryRequest.Name, "Teste1", "Teste2");

        if(!category.IsValid)
        {
            return Results.BadRequest(category.Notifications);
        }

        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}

