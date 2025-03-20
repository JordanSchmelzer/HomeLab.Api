using Microsoft.EntityFrameworkCore;
using HomeLab.Api.DTO;
using System.Collections.Generic;
using HomeLab.Api.Models;


namespace HomeLab.Api.Data
{
    public class MyDbContext : DbContext {

    public DbSet<LabAssetDTO> Asset { get; set; }
    public DbSet<GameEventDTO> game_Events { get; set; }
    public DbSet<Game> Game { get; set; }

    public MyDbContext(DbContextOptions options) : base(options) {
      // DI Options To Base
    }

  }
}