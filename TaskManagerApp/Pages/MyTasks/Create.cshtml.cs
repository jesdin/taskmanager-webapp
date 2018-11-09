using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.MyTasks
{
    public class CreateModel : PageModel
    {
        private readonly TaskManagerApp.Models.TaskManagerAppContext _context;

        public CreateModel(TaskManagerApp.Models.TaskManagerAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MyTask MyTask { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MyTask.Add(MyTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}