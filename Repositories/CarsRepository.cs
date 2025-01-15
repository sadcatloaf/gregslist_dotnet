



namespace gregslist_dotnet.Repositories;

public class CarsRepository
{
  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  internal List<Car> GetAllCars()
  {
    string sql = @"
    SELECT 
    cars.*,
    accounts.*
    FROM cars 
    JOIN accounts ON cars.creator_id = accounts.id;";

    List<Car> cars = _db.Query(sql, (Car car, Account account) =>
    {
      car.Creator = account;
      return car;
    }).ToList();

    return cars;
  }

  internal Car GetCarById(int carId)
  {
    string sql = @"
    SELECT 
    cars.*,
    accounts.*
    FROM cars
    JOIN accounts ON cars.creator_id = accounts.id
    WHERE cars.id = @carId;";

    Car car = _db.Query(sql, (Car car, Account account) =>
    {
      car.Creator = account;
      return car;
    }, new { carId }).SingleOrDefault();

    return car;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO 
    cars(make, model, year, price, color, img_url, description, engine_type, mileage, has_clean_title, creator_id)
    VALUES(@Make, @Model, @Year, @Price, @Color, @ImgUrl, @Description, @EngineType, @Mileage, @HasCleanTitle, @CreatorId);
    
    SELECT
    cars.*,
    accounts.*
    FROM cars
    JOIN accounts ON cars.creator_id = accounts.id
    WHERE cars.id = LAST_INSERT_ID();";

    Car car = _db.Query(sql, (Car car, Account account) =>
    {
      car.Creator = account;
      return car;
    }, carData).SingleOrDefault();

    return car;
  }

  internal void DeleteCar(int carId)
  {
    string sql = "DELETE FROM cars WHERE id = @id LIMIT 1;";
    //                                      { id: 3 }
    int rowsAffected = _db.Execute(sql, new { id = carId });

    if (rowsAffected == 0) throw new Exception("DELETE WAS UNSUCCESSFUL");
    if (rowsAffected > 1) throw new Exception("DELETE WAS TOO SUCCESSFUL");
  }

  internal void UpdateCar(Car carData)
  {
    string sql = @"
    UPDATE cars
    SET
    make = @Make,
    model = @Model,
    price = @Price,
    has_clean_title = @HasCleanTitle
    WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, carData);

    if (rowsAffected == 0) throw new Exception("UPDATE WAS UNSUCCESSFUL");
    if (rowsAffected > 1) throw new Exception("UPDATE WAS TOO SUCCESSFUL");
  }
}