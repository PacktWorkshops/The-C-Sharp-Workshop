using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.App.Data;
using ToDoList.App.Models;

namespace ToDoList.App.Pages
{
    public class EditModel : PageModel
    {
        private readonly ToDoDbContext _context;

        public EditModel(ToDoDbContext context)
        {
            _context = context;
        }

        public Task Task { get; set; }

        public IActionResult OnGet(Guid id)
        {
            Task = _context.Find<Task>(id);

            if (Task == null)
            {
                return RedirectToPage("Create");
            }

            return Page();
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync(Guid id)
        {
            var task = _context.Find<Task>(id);

            if (await TryUpdateModelAsync(task, "Task"))
            {
                _context.Update(task);

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Task successfully updated";
            }            

            return RedirectToPage("Index");
        }
    }
}
