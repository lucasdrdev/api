namespace AppRequests.Endpoints.Products;

public record class ProductResponse (string Name, string Code, string CategoryName, string Description, bool HasStock, bool Active);

