namespace CrunchVote.Domain;
public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> Changes;

    public int version { get; private set; }

    public AggregateRoot() => this.Changes = new();

    public IEnumerable<IDomainEvent> GetChanges() => this.Changes.AsEnumerable();

    public void ClearChanges() => this.Changes.Clear();

    protected abstract void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent);

    protected abstract void ValidateState();

    protected void ApplyDomainEvent(IDomainEvent domainEvent)
    {
        this.ChangeStateByUsingDomainEvent(domainEvent);
        this.ValidateState();
        this.Changes.Add(domainEvent);
        this.version++;

    }

    public void Load(IEnumerable<IDomainEvent> history)
    {
        foreach (var domainEvent in history)
        {
            this.ApplyDomainEvent(domainEvent);
        }
        this.ClearChanges();

    }


}