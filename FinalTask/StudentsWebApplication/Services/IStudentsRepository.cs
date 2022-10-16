using Students.Data;

namespace StudentsWebApplication.Services
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetAll();

        Student? GetById(int id);

        int Add(Student item);

        bool Edit(Student item);

        bool Remove(int id);
    }
}
