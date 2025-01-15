using System.ComponentModel.DataAnnotations;

namespace gregslist_dotnet.Models;

public class Car
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MinLength(3), MaxLength(30)] public string Make { get; set; }
  [MaxLength(100)] public string Model { get; set; }
  [Range(1886, 2025)] public int? Year { get; set; }
  [Range(0, 1000000)] public int? Price { get; set; }
  public string Color { get; set; }
  [Url] public string ImgUrl { get; set; }
  public string Description { get; set; }
  public string EngineType { get; set; }
  public int Mileage { get; set; }
  public bool? HasCleanTitle { get; set; }
  public string CreatorId { get; set; }
  public Account Creator { get; set; }
}