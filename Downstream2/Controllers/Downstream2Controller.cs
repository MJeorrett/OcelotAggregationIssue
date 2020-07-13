using Microsoft.AspNetCore.Mvc;

namespace Downstream2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Downstream2Controller : ControllerBase
    {
        [HttpGet]
        public Downstream2Model Get()
        {
            return new Downstream2Model
            {
                Name = "Data from downstream 2."
            };
        }

        public class Downstream2Model
        {
            public string Name { get; set; }
        }
    }
}
