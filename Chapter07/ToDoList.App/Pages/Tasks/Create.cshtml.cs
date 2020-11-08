using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.App.Data;
using ToDoList.App.Models;

namespace ToDoList.App.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ToDoDbContext _context;

        public CreateModel(ToDoDbContext context)
        {
            _context = context;
        }

        public Task Task { get; set; }

        public void OnGet()
        {
            Task = new Task();
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync()
        {
            var newTask = new Task();

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
}
