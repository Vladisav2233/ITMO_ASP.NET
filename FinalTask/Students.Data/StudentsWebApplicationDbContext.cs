using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data
{
    public class StudentsWebApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }


        public StudentsWebApplicationDbContext(DbContextOptions options) : base(options) { }

    }
}
