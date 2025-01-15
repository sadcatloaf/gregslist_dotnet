namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/houses")]

public class HousesController : ControllerBase
{
    public HousesController(HousesService housesService)
    {
        _housesService = housesService;
    }
    private readonly HousesService _housesService

        [HttpGet "Test"]
    public string Test()
    {
        return "Houses controller works!";
    }
}