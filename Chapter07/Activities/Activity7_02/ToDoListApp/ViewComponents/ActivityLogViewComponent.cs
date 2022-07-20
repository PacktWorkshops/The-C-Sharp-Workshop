using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Data;

namespace ToDoList.App.ViewComponents
{
    public class ActivityLogViewComponent : ViewComponent
    {
        private readonly ToDoDbContext _context;
        private readonly ILogger<ActivityLogViewComponent> _logger;

        public ActivityLogViewComponent(ToDoDbContext context,
            ILogger<ActivityLogViewComponent> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string taskId)
        {
            var activities = await _context.Activities
                .Where(a => EF.Functions.Like(a.EntityId, taskId))
                .ToListAsync();

            _logger.LogInformation($"{activities.Count} actitivites found");

            return View(activities);
        }
    }
}