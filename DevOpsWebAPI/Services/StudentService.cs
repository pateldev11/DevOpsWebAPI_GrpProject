using DevOpsWebAPI.Models;

namespace DevOpsWebAPI.Services
{
    public class StudentService
    {
        private List<Student> students = new();

        public IEnumerable<Student> GetAll() => students;

        public Student? GetById(int id) => students.FirstOrDefault(s => s.Id == id);

        public void Add(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
        }
    }
}
