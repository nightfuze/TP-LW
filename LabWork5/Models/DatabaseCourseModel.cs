using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabWork5.Models
{
    public class DatabaseCourseModel
    {
        [DisplayName("ID курса")]
        public int CourseId { get; set; }

        [DisplayName("Название курса")]
        public string? CourseName { get; set; }

        [DisplayName("Описание курса")]
        public string? Description { get; set; }

        [DisplayName("Преподаватель")]
        public string? Teacher { get; set; }

        [DisplayName("Дата начала")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("Дата окончания")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DisplayName("Номер телефона преподавателя")]
        [DataType(DataType.PhoneNumber)]
        public string? TeacherPhone { get; set; }
    }
}
