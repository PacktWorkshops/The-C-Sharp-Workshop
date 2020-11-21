using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.App.Data;

namespace ToDoList.App.ViewComponents
{
    public class StatsViewComponent : ViewComponent
    {
        private readonly ToDoDbContext _context;
        public StatsViewComponent(ToDoDbContext context)
        {
            _context = context;

        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var delayedTasks = await _context.Tasks.Where(t =>
                         t.DueTo < DateTime.Today
                       && t.Status != Models.ETaskStatus.Done)
                       .CountAsync();

            var dueToday = await _context.Tasks.Where(t =>
                         t.DueTo.HasValue
                       && t.DueTo.Value.Date == DateTime.Today
                       && t.Status != Models.ETaskStatus.Done)
                       .CountAsync();

            return View(new StatsViewModel
            {
                Delayed = delayedTasks,
                DueToday = dueToday
            });
        }

    }
}