using Microsoft.AspNetCore.Mvc;
using DevOpsWebAPI.Models;
using System.Collections.Generic;

namespace DevOpsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Program = "Software Engineering" },
            new Student { Id = 2, Name = "Bob", Program = "Cybersecurity" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(students);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);
            return CreatedAtAction(nameof(GetAll), new { id = student.Id }, student);
        }
    }
}
