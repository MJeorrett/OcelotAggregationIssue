using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Downstream1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Downstream1Controller : ControllerBase
    {
        
        private readonly ILogger<Downstream1Controller> _logger;

        public Downstream1Controller(ILogger<Downstream1Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Downstream1Model Get()
        {
            return new Downstream1Model
            {
                Name = "Data from downstream 1",
            };
        }

        public class Downstream1Model
        {
            public string Name { get; set; }
        }
    }
}
