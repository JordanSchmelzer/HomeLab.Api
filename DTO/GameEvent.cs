namespace HomeLab.Api.DTO 
{
  public class GameEventDTO {
    public int Id { get; set; }
    public string? CardPlayed { get; set; } = string.Empty;
    public string? CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
  }
}
 