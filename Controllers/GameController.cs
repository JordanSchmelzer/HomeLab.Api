using HomeLab.Api.Data;
using HomeLab.Api.DTO;
using HomeLab.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HomeLab.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GameController : ControllerBase {
    private readonly MyDbContext _dbContext;

    public GameController(MyDbContext dbContext) {
      _dbContext = dbContext;
    }

    //GET api/assets
    [HttpGet]
    public async Task<IActionResult> Get() {
      var assets = await _dbContext.game_Events.ToListAsync();
      return Ok(assets);
    }


    [HttpPost("create")]
    public async Task<IActionResult> PostEvent([FromBody] GameEventDTO events) {
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


    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] Game createGame) {
      try {
        _dbContext.Game.Add(createGame);
        await _dbContext.SaveChangesAsync();
      }
      catch {

      }
      //var asset = await _dbContext.Asset.FindAsync(id);
      return CreatedAtAction(nameof(GetGameById), new {id = createGame.Id}, createGame);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetGameById(int id) {
      var game = await _dbContext.Game.FindAsync(id);
      if (game == null) {
        return NotFound();
      }
      return Ok(game);
    }

  }
}
