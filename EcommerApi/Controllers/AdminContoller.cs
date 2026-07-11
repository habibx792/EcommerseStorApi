//using EcommerApi.Models;
using EcommerApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcommerApi.Controllers
{
    [ApiController]
    [Route("Home")]
    public class AdminContoller : ControllerBase
    {
        private readonly ProjectDbContext context;
        public AdminContoller(ProjectDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<string> WelcomeMessage()
        {
            return Ok("Welcome To Xians Ecommer Web Store");
        }
    }
}
