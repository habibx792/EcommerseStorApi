using EcommerApi.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectClasses;

namespace EcommerApi.Controllers
{
    [ApiController]
    [Route("Home")]
    public class ShipmentRiderController:ControllerBase
    {
        public readonly ProjectDbContext context;
        public ShipmentRiderController(ProjectDbContext context)
        {
            this.context= context;
        }
        [HttpPost("RegisterRider")]
        public async Task<ActionResult<ShipmentRider>> RegisterShipmentRider(ShipmentRider sh)
        {
            await context.Users.AddAsync(sh);
            context.SaveChangesAsync();
            return sh;
        }
    }
}
