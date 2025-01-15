

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
    string sql = @"SELECT * FROM cars WHERE id = @carId;";

    Car car = _db.Query<Car>(sql, new { carId }).SingleOrDefault();

    return car;
  }
}