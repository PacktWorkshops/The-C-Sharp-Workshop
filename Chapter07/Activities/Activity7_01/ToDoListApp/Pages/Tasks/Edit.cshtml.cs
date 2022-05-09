using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.Tasks;

public class EditModel : PageModel
{
    private readonly ToDoDbContext _context;

    public EditModel(ToDoDbContext context)
    {
        _context = context;
    }

    public ToDoTask Task { get; set; }


    public IActionResult OnGet(Guid id)
    {
        Task = _context.Tasks.Find(id);

        if (Task is null)
        {
            return RedirectToPage("Create");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        var task = _context.Tasks.Single(t => t.Id == id);

        if (await TryUpdateModelAsync(task, "Task"))
        {
            _context.Update(task);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Task successfully updated";
        }

        return RedirectToPage("Index");
    }
}
