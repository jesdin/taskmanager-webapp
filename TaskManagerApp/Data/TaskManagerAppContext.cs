using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerApp.Models
{
    public class TaskManagerAppContext : DbContext
    {
        public TaskManagerAppContext (DbContextOptions<TaskManagerAppContext> options)
            : base(options)
        {
        }

        public DbSet<TaskManagerApp.Models.MyTask> MyTask { get; set; }
    }
}
