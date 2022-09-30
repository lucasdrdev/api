using Flunt.Validations;

namespace AppRequests.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public bool HasStock { get; set; }
    public bool Active { get; set; } = true;

    private Product() { }

    public Product(string name, string code, Category category, string description, bool hasStock)
    {
        Name = name;
        Category = category;
        Description = description;
        HasStock = hasStock;
        Code = code;
        
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Product>()
             .IsNotNullOrEmpty(Name, "Name")
             .IsGreaterOrEqualsThan(Name, 3, "Name")
             .IsNotNullOrEmpty(Code, "Code")
             .IsNotNull(Category, "Category")
             .IsNotNullOrEmpty(Description, "Description")
             .IsGreaterOrEqualsThan(Description, 3, "Description");
             
        AddNotifications(contract);
    }
}
