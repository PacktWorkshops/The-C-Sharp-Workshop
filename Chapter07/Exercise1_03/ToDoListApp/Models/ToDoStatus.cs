namespace ToDoListApp.Models;

public class ToDoTask
{
    public ToDoTask()
    {
        CreatedAt = DateTime.UtcNow;
        Id = Guid.NewGuid();
    }

    public ToDoTask(string title, ETaskStatus status) : this()
    {
        Title = title;
        Status = status;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DueTo { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public ETaskStatus Status { get; set; }
}
