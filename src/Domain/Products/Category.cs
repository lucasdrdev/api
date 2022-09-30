using Flunt.Validations;


namespace AppRequests.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name, string createdBy, string editedBy)
    {
        //Validações com contract class
        var contract = new Contract<Category>();
        contract.IsNotNullOrWhiteSpace(name, "Name", "Nome é obrigatório.");
        contract.IsNotNullOrEmpty(createdBy, "CreatedBy");
        contract.IsNotNullOrEmpty(editedBy, "EditedBy");
        AddNotifications(contract);

        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;
    }
}
