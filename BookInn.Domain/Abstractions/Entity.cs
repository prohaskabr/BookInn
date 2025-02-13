namespace BookInn.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; set; }

    protected Entity(Guid id)
    {
        Id = id;
    }
}