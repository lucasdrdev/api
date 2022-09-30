
namespace AppRequests.Endpoints.Products;

public class ProductRequest
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid CategoryId { get; set; }
    public string Description { get; set; }
    public bool HasStock { get; set; }
    public bool Active { get; set; } = true;


}