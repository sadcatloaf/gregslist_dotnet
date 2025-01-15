
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

    List<Car> cars = _db.Query<Car, Account, Car>(sql, (car, account) =>
    {
      car.Creator = account;
      return car;
    }).ToList();
    return cars;
  }
}