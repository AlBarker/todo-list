using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoList.API.Services;
using Task = TodoList.API.Models.Task;

namespace TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IStorageService<Task> _storageService;

        public TaskController(IStorageService<Task> storageService)
        {
            _storageService = storageService;
        }

        // GET api/values
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<Task>>> Get()
        {
            return await _storageService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> Get(int id)
        {
            return await _storageService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Task task)
        {
            var createdTask = _storageService.Add(task);

            return CreatedAtAction("Task", createdTask);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Task task)
        {
            var updatedTask = _storageService.Update(task);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _storageService.Delete(new Task { Id = id });

            return Ok();
        }
    }
}
