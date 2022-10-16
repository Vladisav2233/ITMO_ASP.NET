using Students.Data;

namespace StudentsWebApplication.Services.Impl
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly StudentsWebApplicationDbContext _context;

        public StudentsRepository(StudentsWebApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Student item)
        {
            _context.Students.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public bool Edit(Student item)
        {
            var student = GetById(item.Id);
            if (student != null)
            {
                student.LastName = item.LastName;
                student.FirstName = item.FirstName;
                student.Patronymic = item.Patronymic;
                student.Birthday = item.Birthday;
                student.Grade1 = item.Grade1;
                student.Grade2 = item.Grade2;
                student.Grade3 = item.Grade3;

                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student? GetById(int id)
        {
            return _context.Students.FirstOrDefault(student => student.Id == id);
        }

        public bool Remove(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
