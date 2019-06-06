using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerApp.Models
{
    public class MyTask
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsHighPriority { get; set; }
    }
}
