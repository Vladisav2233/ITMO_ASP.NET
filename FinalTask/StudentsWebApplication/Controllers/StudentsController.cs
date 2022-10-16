using Microsoft.AspNetCore.Mvc;
using Students.Data;
using StudentsWebApplication.Services;
using StudentsWebApplication.Services.Impl;
using StudentsWebApplication.ViewModels;

namespace StudentsWebApplication.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }


        public IActionResult Index()
        {
            var students = _studentsRepository.GetAll();

            return View(new DisplayStudentsViewModel
            {
                Students = students
            });
        }

        public IActionResult Create()
        {
            return View("Edit", new StudentViewModel());
        }


        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return View(new StudentViewModel());
            }

            var student = _studentsRepository.GetById((int)id);
            if (student is null)
                return NotFound();

            return View(new StudentViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Patronymic = student.Patronymic,
                Birthday = student.Birthday,
                Grade1 = student.Grade1,
                Grade2 = student.Grade2,
                Grade3 = student.Grade3
            });
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel studentsViewModel)
        {
            var student = new Student
            {
                Id = studentsViewModel.Id,
                LastName = studentsViewModel.LastName,
                FirstName = studentsViewModel.FirstName,
                Patronymic = studentsViewModel.Patronymic,
                Birthday = studentsViewModel.Birthday,
                Grade1 = studentsViewModel.Grade1,
                Grade2 = studentsViewModel.Grade2,
                Grade3 = studentsViewModel.Grade3,
            };

            if (studentsViewModel.Id == 0)
            {
                _studentsRepository.Add(student);
            }
            else
            {
                _studentsRepository.Edit(student);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_studentsRepository.Remove(id))
                return NotFound();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = _studentsRepository.GetById(id);
            if (student is null)
                return NotFound();

            return View(new StudentViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Patronymic = student.Patronymic,
                Birthday = student.Birthday,
                Grade1 = student.Grade1,
                Grade2 = student.Grade2,
                Grade3 = student.Grade3
            });
        }



    }
}
