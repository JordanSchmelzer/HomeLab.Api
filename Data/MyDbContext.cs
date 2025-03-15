using Microsoft.EntityFrameworkCore;
using HomeLab.Api.Models;
using System.Collections.Generic;


namespace HomeLab.Api.Data {
  public class MyDbContext : DbContext {
    public DbSet<LabAsset> Asset { get; set; }
    public DbSet<GameEvent> game_Events { get; set; }
    public MyDbContext(DbContextOptions options) : base(options) {
      // DI Options To Base
    }
  }
}