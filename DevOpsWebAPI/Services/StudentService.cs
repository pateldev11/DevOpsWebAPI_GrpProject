using DevOpsWebAPI.Models;

namespace DevOpsWebAPI.Services
{
    public class StudentService
    {
        private List<Student> students = new();

        public IEnumerable<Student> GetAll() => students;

        public void Add(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
        }
    }
}
