namespace gregslist_dotnet.Services;

public class CarsService
{
  public CarsService(CarsRepository repository)
  {
    _repository = repository;
  }

  // each service should only talk to one repository
  private readonly CarsRepository _repository;


  // NOTE public and internal both work here
  internal List<Car> GetAllCars()
  {
    List<Car> cars = _repository.GetAllCars();
    return cars;
  }

  internal Car GetCarById(int carId)
  {
    Car car = _repository.GetCarById(carId);

    if (car == null) throw new Exception($"Invalid car id: {carId}");

    return car;
  }

  internal Car CreateCar(Car carData)
  {
    Car car = _repository.CreateCar(carData);

    return car;
  }

  internal string DeleteCar(int carId, string userId)
  {
    Car car = GetCarById(carId);

    if (car.CreatorId != userId) throw new Exception("THIS IS NOT YOUR CAR, BUD");

    _repository.DeleteCar(carId);

    return $"Deleted the {car.Make} {car.Model}!";
  }

  internal Car UpdateCar(int carId, string userId, Car carUpdateData)
  {

    Car car = GetCarById(carId);

    if (car.CreatorId != userId) throw new Exception("THIS IS NOT YOUR CAR, PAL");

    // if make is null in request body, default back to original make
    car.Make = carUpdateData.Make ?? car.Make;

    car.Model = carUpdateData.Model ?? car.Model;

    // NOTE Price must be nullable in Car model to perform this check (numbers default to 0)
    car.Price = carUpdateData.Price ?? car.Price;

    // NOTE HasCleanTitle must be nullable in Car model to perform this check (bools default to false)
    car.HasCleanTitle = carUpdateData.HasCleanTitle ?? car.HasCleanTitle;

    // NOTE don't forget to update the database
    _repository.UpdateCar(car);

    return car;
  }
}