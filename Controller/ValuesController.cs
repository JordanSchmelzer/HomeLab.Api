using HomeLab.Api.Data;
using HomeLab.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeLab.Api.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class GameEventsController : ControllerBase {
    private readonly MyDbContext _dbContext;

    public GameEventsController(MyDbContext dbContext) {
      _dbContext = dbContext;
    }

    //GET api/assets
    [HttpGet]
    public async Task<IActionResult> Get() {
      var assets = await _dbContext.game_Events.ToListAsync();
      return Ok(assets);
    }


    [HttpPost()]
    public async Task<IActionResult> PostEvent([FromBody] GameEvent events) {
      var game_events = new object();
      try {
        _dbContext.game_Events.Add(events);
        await _dbContext.SaveChangesAsync();
      }
      catch (Exception ex) {
        Console.WriteLine(ex);
        //await return StatusCode(500);
      }
      Console.WriteLine("ok");
      return CreatedAtAction(nameof(Get), new { id = events.Id }, events);
    }
  }
}
