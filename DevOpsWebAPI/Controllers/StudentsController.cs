using Microsoft.AspNetCore.Mvc;
using DevOpsWebAPI.Models;

namespace DevOpsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Program = "Software Engineering", Email = "alice@example.com" },
            new Student { Id = 2, Name = "Bob", Program = "Cybersecurity", Email = "bob@example.com" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }
    }
}
