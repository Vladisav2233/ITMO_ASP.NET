using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StudentsWebApplication.ViewModels
{
    public class StudentViewModel
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        public string? FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }

        [Display(Name = "День рождения")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Оценка1")]
        public float Grade1 { get; set; }

        [Display(Name = "Оценка2")]
        public float Grade2 { get; set; }

        [Display(Name = "Оценка3")]
        public float Grade3 { get; set; }
    }
}
