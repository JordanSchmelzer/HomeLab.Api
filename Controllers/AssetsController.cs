using HomeLab.Api.Data;
using HomeLab.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HomeLab.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AssetsController : ControllerBase {
    private readonly MyDbContext _dbContext;

    public AssetsController(MyDbContext dbContext) {
      _dbContext = dbContext;
    }

    //GET api/assets
    [HttpGet]
    public async Task<IActionResult> Get() {
      var assets = await _dbContext.Asset.ToListAsync();
      return Ok(assets);
    }

    //GET api/assets/
    [HttpPost]
    public async Task<IActionResult> CreateAsset([FromBody] LabAssetDTO asset) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      _dbContext.Asset.Add(asset);
      await _dbContext.SaveChangesAsync();

      return CreatedAtAction(nameof(GetAsset), new { id = asset.Id }, asset);
    }

    //GET api/assets/id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsset(int id) {
      var asset = await _dbContext.Asset.FindAsync(id);
      if (asset == null) {
        return NotFound();
      }
      return Ok(asset);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsset(int id, [FromBody] LabAssetDTO asset) {
      if (id != asset.Id) {
        return BadRequest("Asset Id mismatch.");
      }

      var existingAsset = await _dbContext.Asset.FindAsync(id);
      if (existingAsset == null) {
        return NotFound();
      }

      existingAsset.Name = asset.Name;
      existingAsset.Description = asset.Description;
      existingAsset.Type = asset.Type;

      await _dbContext.SaveChangesAsync();

      return NoContent();
    }


    /*
    //GET api/tasks/1
    [HttpGet("{id}")]
    public ActionResult<LabAsset> Get(int id) {
      var assetItem = _labAssets.FirstOrDefault(x => x.Id == id);
      if (assetItem == null) {
        return NotFound();
      }
      return Ok(assetItem);
    }

    //POST api/tasks
    [HttpPost]
    public ActionResult Post([FromBody] LabAsset asset) {
      _labAssets.Add(asset);
      return CreatedAtAction(nameof(Get), new { id = asset.Id }, asset);
    }

    //PUT api/tasks
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] LabAsset asset) {
      if (id != asset.Id) {
        return BadRequest();
      }

      var assetToUpdate = _labAssets.FirstOrDefault(x => x.Id == id);
      if (assetToUpdate == null) {
        return NotFound();
      }

      assetToUpdate.Name = asset.Name;
      assetToUpdate.Description = asset.Description;
      assetToUpdate.Type = asset.Type;

      return NoContent();
    }

    //DELETE api/tasks/1
    [HttpDelete("{id}")]
    public ActionResult Delete(int id) {
      var assetToDelete = _labAssets.FirstOrDefault(_ => _.Id == id);
      if (assetToDelete == null) {
          return NotFound();
      }
      _labAssets.Remove(assetToDelete);
      return NoContent();
    }

    //POST api//tasks/
    [HttpPost("{id}")]
    public ActionResult Post()
    {
      return NoContent();
    }
  */
  }
}