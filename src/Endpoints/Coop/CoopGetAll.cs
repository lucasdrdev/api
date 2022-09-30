using AppRequests.Domain.Products;
using AppRequests.Infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AppRequests.Endpoints.Coop;

public class CoopGetAll
{
    public static string Template => "/coops";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

   
    public static async Task<IResult> Action(UserManager<IdentityUser> userManager)
    {
        
        var users = await userManager.Users.ToListAsync();
        var coops = users.Select(users => new CoopResponse(users.Email, users.PasswordHash));

        return Results.Ok(coops);
    }
}

