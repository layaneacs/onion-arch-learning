namespace Domain.Entities;
public class TaskItem(Guid id, string title)
{
    public Guid Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public bool IsCompleted { get; private set; } = false;

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
}
