

namespace gregslist_dotnet.Services;

public class CarsService
{
  public CarsService(CarsRepository repository)
  {
    _repository = repository;
  }

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
}