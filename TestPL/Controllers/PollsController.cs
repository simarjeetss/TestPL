using Microsoft.AspNetCore.Mvc;
using TestPL.Models;
using TestPL.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly IPollService pollService;

        public PollsController(IPollService pollService)
        {
            this.pollService = pollService;
        }
        // GET: api/<PollsController>
        [HttpGet]
        public ActionResult<List<Question>> Get()
        {
            return pollService.Get();
        }

        // GET api/<PollsController>/5
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            var question = pollService.Get(id);
            
            if(question == null)
            {
                return NotFound($"Question with Id = {id} not found");
            }

            return question;
        }

        // POST api/<PollsController>
        [HttpPost]
        public ActionResult<Question> Post([FromBody] Question question)
        {
            pollService.Create(question);

            return CreatedAtAction(nameof(Get), new {id = question.id }, question);
        }

        // PUT api/<PollsController>/5
        [HttpPut("{id}")]
        public ActionResult<Question> Put(int id, [FromBody] Question question)
        {
            var existingQuestion = pollService.Get(id);

            if(existingQuestion == null)
            {
                return NotFound($"Question with Id = {id} not found");
            }
            pollService.Update(id, question);

            return NoContent();
        }

        // DELETE api/<PollsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var question = pollService.Get(id);

            if(question == null)
            {
                return NotFound($"Question with Id = {id} not found");
            }

            pollService.Remove(id);

            return Ok($"Question with Id = {id} deleted");
        }
    }
}
