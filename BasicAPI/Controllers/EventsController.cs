using BasicAPI;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event> { new Event { Id = 1,Title="I hate this project",Start=new DateOnly(2023,9,1) } , new Event { Id = 2, Title = " event2" , Start = new DateOnly(2023, 9, 8) } ,
            new Event { Id = 3, Title = "default event",Start = new DateOnly(2023, 6, 1) }, new Event {Id = 4, Title = "borred",Start = new DateOnly(2023, 6, 1) } };
        private static int counter = 5;
        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(events);
        }

        //GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Event eve = events.Find(e => e.Id == id);
            if (eve == null)
                return NotFound();
            return Ok(eve);
        }
        //POST api/<EventsController>
        [HttpPost]
        public ActionResult Post([FromBody] Event newEvent)
        {
            events.Add(new Event { Id = ++counter, Title = newEvent.Title, Start = newEvent.Start });
            return Ok();
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event newEvent)
        {
            var e = events.Find(ev => ev.Id == id);
            if (e == null)
                return NotFound();
            e.Title = newEvent.Title;
            e.Start = newEvent.Start;
            return Ok();

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            if (eve == null)
                return NotFound();
            events.Remove(eve);
            return Ok();
        }
    }
}