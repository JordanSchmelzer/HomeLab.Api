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

    public GameController(MyDbContext dbContext)
    {
      _dbContext = dbContext;
    }


    [HttpPost("CreateNew")]
    public async Task<IActionResult> ExecuteNewGame([FromBody] Game newGame) 
    {
      if (newGame.Player == null) 
      {
        return this.BadRequest("Cannot have null parameters.");
      }
      _dbContext.Game.Add(newGame);
      await _dbContext.SaveChangesAsync();
      return CreatedAtAction(nameof(GetGameById), new { id = newGame.Id }, newGame);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetGameById(int id) 
    {
      var game = await _dbContext.Game.FindAsync(id);
      if (game == null) 
      {
        return NotFound();
      }
      return Ok(game);
    }


    [HttpPost("NewEvent")]
    public async Task<IActionResult> NewEvent([FromBody] GameEventDTO myEvent) {
      _dbContext.GameEvents.Add(myEvent);
      await _dbContext.SaveChangesAsync();
      return CreatedAtAction(nameof(NewEvent), new { id = myEvent.Id }, myEvent);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> ExecuteUpdateGame([FromBody] Game game) {
      _dbContext.Game.Update(game);
      await _dbContext.SaveChangesAsync();
      return Ok(game);
    } 
  }
}
