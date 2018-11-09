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

        // GET: api/MyTasks/5
        [HttpGet("{id}")]
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

        // PUT: api/MyTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyTask([FromRoute] int id, [FromBody] MyTask myTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myTask.ID)
            {
                return BadRequest();
            }

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

        // POST: api/MyTasks
        [HttpPost]
        public async Task<IActionResult> PostMyTask([FromBody] MyTask myTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MyTask.Add(myTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyTask", new { id = myTask.ID }, myTask);
        }

        // DELETE: api/MyTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyTask([FromRoute] int id)
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

            _context.MyTask.Remove(myTask);
            await _context.SaveChangesAsync();

            return Ok(myTask);
        }

        private bool MyTaskExists(int id)
        {
            return _context.MyTask.Any(e => e.ID == id);
        }
    }
}