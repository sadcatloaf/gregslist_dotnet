namespace gregslist_dotnet.Models;

public class House
{
    public int Id { get; set; }
    public int Sqft { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public string ImgUrl { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}




// CREATE TABLE houses(
//   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
//   sqft INT NOT NULL,
//   bedrooms INT NOT NULL,
//   bathrooms DOUBLE NOT NULL,
//   imgUrl VARCHAR(255) NOT NULL,
//   description VARCHAR(255) NOT NULL,
//   price INT NOT NULL,
// createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
// updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
// );