using Microsoft.AspNetCore.Mvc;

namespace KeyManager.Controllers;

[ApiController]
[Route("[controller]")]
public class KeyManagement : ControllerBase
{
 

    private readonly ILogger<KeyManagement> _logger;

    public KeyManagement(ILogger<KeyManagement> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCarInfo")]
    public string Get()
    {
        return "Woah";
    }
}
