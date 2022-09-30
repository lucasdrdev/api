
using Microsoft.AspNetCore.Identity;


namespace AppRequests.Endpoints.Coop;

public class CoopPost
{
    public static string Template => "/coops";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

    public static Delegate Handle => Action;


    public static async Task<IResult> Action(CoopRequest coopRequest, UserManager<IdentityUser> userManager)
    {
        //Identity
        var user = new IdentityUser { 
            UserName = coopRequest.Email,
            Email = coopRequest.Email            
        };
        var result = await userManager.CreateAsync(user, coopRequest.Password);

        if (!result.Succeeded)
        {
            return Results.BadRequest(result.Errors.First());
        }

        return Results.Created($"/coops/{user.Id}", user.Id);
    }
}

