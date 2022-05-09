using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoDbContext _context;

        public IndexModel(ToDoDbContext context)
        {
            _context = context;
        }

        public IList<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();

        public void OnGet()
        {
            Tasks = _context.Tasks.ToList();
        }

        public IActionResult OnPostStartTask(Guid id)
        {
            return ChangeTaskStatus(id, ETaskStatus.ToDo, ETaskStatus.Doing);
        }

        public IActionResult OnPostEndTask(Guid id)
        {
            return ChangeTaskStatus(id, ETaskStatus.Doing, ETaskStatus.Done);
        }

        private IActionResult ChangeTaskStatus(Guid id, ETaskStatus current, ETaskStatus next)
        {
            var task = _context.Find<ToDoTask>(id);

            if (task != null && task.Status == current)
            {
                task.Status = next;

                _context.Update(task);

                _context.SaveChanges();
            }

            Tasks = _context.Tasks.ToList();

            Request.QueryString = default;

            return RedirectToPage("Index");
        }
    }
}
