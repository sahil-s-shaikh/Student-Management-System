using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LOGIN USER
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (login == null)
                return BadRequest("Login data missing");

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid email or password");

            return Ok(user);
        }
    }
    }

