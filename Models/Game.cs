using System.ComponentModel.DataAnnotations;

namespace HomeLab.Api.Models
{
  public class Game
  {
    [Key]
    public int Id { get; set; }
    public string GameType { get; set; }
    public string Player { get; set; }
    public string Winner { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set;}
  }
}
