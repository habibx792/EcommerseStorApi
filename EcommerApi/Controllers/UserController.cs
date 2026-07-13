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
    public class UserController : ControllerBase
    {
        private readonly ProjectDbContext context;
        public UserController(ProjectDbContext context)
        {
            this.context = context;
        }
        [HttpDelete("DeleteUser/{id}")]

        public async Task<ActionResult> DeleteUser(int id)
        {
            var user=await context.Users.FindAsync(id);
            if (user == null)
            {
                Ok(new { message = "User Does not Exist" });
            }
            context.Users.Remove(user);
            int row = await context.SaveChangesAsync();
            return Ok(new { message = "User Has Been Deleted " });

        }
        public User getUserById(int id)
        {
            // Find() looks up by primary key directly and is highly optimized
            var user = context.Users.Find(id);
            return user;
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult> UpdateUser(User newUser, int id)
        {
            var user = getUserById(id);
            if (user == null)
            {
                return Ok(new { message = "User Does Not Exist" });
            }
            //user.Id = newUser.Id;
            user.Name = newUser.Name;
            user.Email = newUser.Email;
            user.Password = newUser.Password;
            user.Confirm = user.Confirm;
            user.ModifiedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return Ok(user);
        }
            

        
        [HttpGet("GetUsers/{id}")]
        public async Task<ActionResult<User>>GetSpecificUser(int id)
        {
            var user = getUserById(id);
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
