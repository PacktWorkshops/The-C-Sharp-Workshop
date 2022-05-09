using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.Models;

namespace ToDoListApp.Pages;

public class IndexModel : PageModel
{
    public IList<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();

    public IndexModel()
    {
    }

    public void OnGet()
    {
        Tasks = new List<ToDoTask>
            {
                new ToDoTask("Create", ETaskStatus.ToDo),
                new ToDoTask("Creating", ETaskStatus.Doing),
                new ToDoTask("Created", ETaskStatus.Done),
            };
    }
}
