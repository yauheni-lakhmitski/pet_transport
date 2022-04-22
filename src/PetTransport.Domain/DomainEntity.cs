using MediatR;

namespace PetTransport.Domain;

public abstract class DomainEntity
{
    public Guid Id { get; }

    protected DomainEntity()
    {
        Id = Guid.NewGuid();
    }

    private readonly List<INotification> _domainEvents = new();
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(INotification domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(INotification domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj == null || obj.GetType() != GetType())
            return false;

        var domainEntity = obj as DomainEntity;
        if (domainEntity == null)
            return false;

        return Id.Equals(domainEntity.Id) && domainEntity.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return 324 * Id.GetHashCode();
        }
    }
}