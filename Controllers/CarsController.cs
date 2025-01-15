namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/cars")] // TODO show off fancy thing
public class CarsController : ControllerBase
{
  [HttpGet]
  public string Test()
  {
    return "Cars Controller works!!!!!";
  }
}