using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.Tasks;

public class CreateModel : PageModel
{
    private readonly ToDoDbContext _context;

    public CreateModel(ToDoDbContext context)
    {
        _context = context;
    }

    public ToDoTask Task { get; set; }


    public void OnGet()
    {
        Task = new ToDoTask();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var newTask = new ToDoTask();

        if (await TryUpdateModelAsync(newTask, "Task"))
        {
            Task = newTask;

            await _context.AddAsync(Task);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Task successfully created";

            return RedirectToPage("Index");
        }

        return Page();
    }
}
