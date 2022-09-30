using AppRequests.Endpoints.Categories;
using AppRequests.Endpoints.Coop;
using AppRequests.Endpoints.Products;
using AppRequests.Infra.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(
    builder.Configuration["ConnectionString:AppRequestsDb"]);
builder.Services.AddIdentity<IdentityUser, IdentityRole>(Options =>
{
    Options.Password.RequireNonAlphanumeric = false;
    Options.Password.RequireUppercase = false;
    Options.Password.RequireLowercase = false;
    Options.Password.RequireDigit = false;
    Options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);
app.MapMethods(CategoryGetAll.Template, CategoryGetAll.Methods, CategoryGetAll.Handle);
app.MapMethods(CategoryPut.Template, CategoryPut.Methods, CategoryGetAll.Handle);
app.MapMethods(CoopPost.Template, CoopPost.Methods, CoopPost.Handle);
app.MapMethods(CoopGetAll.Template, CoopGetAll.Methods, CoopGetAll.Handle);
app.MapMethods(ProductPost.Template, ProductPost.Methods, ProductPost.Handle);
app.MapMethods(ProductGetAll.Template, ProductGetAll.Methods, ProductGetAll.Handle);
app.MapMethods(ProductGetCode.Template, ProductGetCode.Methods, ProductGetCode.Handle);
app.MapMethods(ProductEdit.Template, ProductEdit.Methods, ProductEdit.Handle);
app.MapMethods(ProductRemove.Template, ProductRemove.Methods, ProductRemove.Handle);

app.Run();

