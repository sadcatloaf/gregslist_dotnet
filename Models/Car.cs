using System.ComponentModel.DataAnnotations;

namespace gregslist_dotnet.Models;
public class Car
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MinLength(3), MaxLength(30)] public string Make { get; set; }
  [MaxLength(100)] public string Model { get; set; }
  // ? denotes that this property will default to null instead of 0 when casting an object into this class
  [Range(1886, 2025)] public int? Year { get; set; }
  [Range(0, 1000000)] public int? Price { get; set; }
  public string Color { get; set; }
  [Url] public string ImgUrl { get; set; }
  public string Description { get; set; }
  public string EngineType { get; set; }
  public int Mileage { get; set; }
  // ? denotes that this property will default to null instead of false when casting an object into this class
  public bool? HasCleanTitle { get; set; }
  public string CreatorId { get; set; }
  // allows us to send a nested creator object to the client (virtual property)
  public Account Creator { get; set; }
}