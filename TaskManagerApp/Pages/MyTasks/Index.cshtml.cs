using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.MyTasks
{
    public class IndexModel : PageModel
    {
        private readonly TaskManagerApp.Models.TaskManagerAppContext _context;

        public IndexModel(TaskManagerApp.Models.TaskManagerAppContext context)
        {
            _context = context;
        }

        public IList<MyTask> MyTask { get;set; }

        public async Task OnGetAsync()
        {
            MyTask = await _context.MyTask.ToListAsync();
        }
    }
}
