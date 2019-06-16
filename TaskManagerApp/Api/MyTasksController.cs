using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;

namespace TaskManagerApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTasksController : ControllerBase
    {
        private readonly TaskManagerAppContext _context;

        public MyTasksController(TaskManagerAppContext context)
        {
            _context = context;
        }

        // GET: api/MyTasks
        [HttpGet]
        public IEnumerable<MyTask> GetMyTask()
        {
            return _context.MyTask;
        }

        // GET: api/MyTasks/GetTask/5
        [HttpGet("GetTask/{id}")]
        [ProducesResponseType(typeof(MyTask), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMyTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myTask = await _context.MyTask.FindAsync(id);

            if (myTask == null)
            {
                return NotFound();
            }

            return Ok(myTask);
        }

        // POST: api/MyTasks/EditTask/5
        [HttpPost("EditTask/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutMyTask([FromRoute] int id, [FromBody] MyTask myTask)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != myTask.ID) return BadRequest();

            _context.Entry(myTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MyTasks/Create
        [HttpPost("Create")]
        [ProducesResponseType(typeof(MyTask), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostMyTask([FromBody] MyTask myTask)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.MyTask.Add(myTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyTask", new { id = myTask.ID }, myTask);
        }

        // POST: api/MyTasks/Delete/5
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteMyTask([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var myTask = await _context.MyTask.FindAsync(id);
            if (myTask == null) return NotFound();

            _context.MyTask.Remove(myTask);
            await _context.SaveChangesAsync();

            return Ok(myTask);
        }

        [HttpPost("SetAsComplete/{id}")]
        public async Task<IActionResult> SetAsComplete([FromRoute]int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var task = await _context.MyTask.FindAsync(id);

            if (task is null) return NotFound();
            if (task.IsCompleted is true) return Ok();

            task.IsCompleted = true;
            _context.MyTask.Update(task);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPost("SetAsIncomplete/{id}")]
        public async Task<IActionResult> SetAsIncomplete([FromRoute]int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var task = await _context.MyTask.FindAsync(id);

            if (task is null) return NotFound();
            if (task.IsCompleted is false) return Ok();

            task.IsCompleted = false;
            _context.MyTask.Update(task);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool MyTaskExists(int id)
        {
            return _context.MyTask.Any(e => e.ID == id);
        }
    }
}