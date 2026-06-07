using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Students student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 🔥 Duplicate check
            if (await _context.Students.AnyAsync(s => s.Email == student.Email))
            {
                return BadRequest("Email already exists.");
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Students student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != student.Id)
                return BadRequest();

            if (await _context.Students.AnyAsync(s => s.Email == student.Email && s.Id != id))
            {
                return BadRequest("Email already exists.");
            }

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

