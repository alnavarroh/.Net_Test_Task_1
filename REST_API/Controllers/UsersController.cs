using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API.Data;
using REST_API.Model;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly REST_APIContext _context;

        public UsersController(REST_APIContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(User request)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(x => x.Login == request.Login);
                if ((user != null) && (user.Password == request.Password))
                {
                    var response = new
                    {
                        user.Login,
                        user.Role,
                        user.USD_Balance
                    };

                    return Ok(response);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Username or Password not found");
        }

        [HttpPut("updateBalance")]
        public async Task<ActionResult> UpdateBalance(User request)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(x => x.Login == request.Login);
                if (user != null && user.Login == request.Login)
                {
                    user.USD_Balance = request.USD_Balance;
                    _context.Entry(user);

                    await _context.SaveChangesAsync();
                    return Ok($"Balance Updated for user {user.Login} to {user.USD_Balance}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Can't update balance");
        }

        [HttpDelete("deleteUser/{UserToDelete}")]
        public async Task<ActionResult> DeleteUser(string UserToDelete, User user)
        {
            try
            {
                var userRequesting = await _context.User.FirstOrDefaultAsync(x => x.Login == user.Login);
                if (userRequesting != null && userRequesting.Role == "Admin")
                {
                    var request = await _context.User.FirstOrDefaultAsync(x => x.Login == UserToDelete);
                    if (request == null) return NotFound($"User {UserToDelete} not found");

                    _context.Remove(request);

                    await _context.SaveChangesAsync();
                    return Ok($"User {request.Login} deleted successfully");
                }
                else
                {
                    return BadRequest("User can't delete users");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
