using EcommerApi.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectClasses;
using System.Numerics;
namespace EcommerApi.Controllers
{

    [ApiController]
    [Route("User")]
    public class UserController:ControllerBase
    {
        private readonly ProjectDbContext context;
        public UserController(ProjectDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetUsers/{id}")]
        public async Task<ActionResult<User>>GetSpecificUser(int id)
        {
            var user=context.Users.Where(u=>u.Id==id);
            return Ok(user);
        }
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var Users=await context.Users.ToListAsync();
            if(Users!=null)
            {
                return Ok(Users);
            }
            return Ok(new {message="No User Register Yet"});
        }
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(User user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                PhoneNumber = user.PhoneNumber,
                Confirm = BCrypt.Net.BCrypt.HashPassword(user.Password),
                UserAddressId = user.UserAddressId,
                Address = user.Address,

            };
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();

            return Ok(newUser);

        }
        

    }
}
