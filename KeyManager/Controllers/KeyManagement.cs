using KeyManager.Data;
using KeyManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace KeyManager.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class KeyManagement : ControllerBase
    {


        private readonly ILogger<KeyManagement> _logger;
        private QueryController queryController;

        public KeyManagement(ILogger<KeyManagement> logger, DbContextOptions<AppDbContext> options)
        {
            _logger = logger;
            queryController = new(options);
        }

        [HttpGet(Name = "GetAllUsers")]
        public string Get()
        {
            List<User> test = queryController.RetriveAll();
            return test[0].ToString();
        }

        [HttpPost(Name = "AddKey")]
        public string Post()
        {
            queryController.AddUser();
            return "Woah";
        }
    }

}
