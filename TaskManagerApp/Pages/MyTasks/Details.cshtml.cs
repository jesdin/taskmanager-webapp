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
    public class DetailsModel : PageModel
    {
        private readonly TaskManagerApp.Models.TaskManagerAppContext _context;

        public DetailsModel(TaskManagerApp.Models.TaskManagerAppContext context)
        {
            _context = context;
        }

        public MyTask MyTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyTask = await _context.MyTask.FirstOrDefaultAsync(m => m.ID == id);

            if (MyTask == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
