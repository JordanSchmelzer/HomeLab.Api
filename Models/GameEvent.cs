﻿namespace HomeLab.Api.Models {
  public class GameEvent {
    public int Id { get; set; }
    public string? CardPlayed { get; set; } = string.Empty;
    public string? CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
  }
}
 