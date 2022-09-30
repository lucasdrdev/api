using Flunt.Notifications;

namespace AppRequests.Domain.Products;

public abstract class Entity : Notifiable<Notification>
{
    //Construtor para gerar ID sempre que chamada.
    public Entity()
    {
        Id = Guid.NewGuid();       
    }

    public Guid Id { get; set; }

    //Audit
    public string? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? EditedBy { get; set; }
    public DateTime EditedOn { get; set; }
}
