namespace CrunchVote.Domain;
public class DomainEvent<T>
{
    private List<Action<T>> Actions { get; } = new();
    public void Register(Action<T> callback)
    {
        if (this.Actions.Exists(del => del.Method == callback.Method))
            return;
        this.Actions.Add(callback);
    }

    public void Publish(T args)
    {
        foreach (var action in Actions)
        {
            action.Invoke(args);
        }
    }

}