using LabWork5.Models;
using Microsoft.AspNetCore.Html;

namespace LabWork5.Helpers
{
    public static class DatabaseCourseHelper
    {
        public static HtmlString RenderDatabaseCourseList(List<DatabaseCourseModel> courses)
        {
            var html = "<table class='table'><thead><tr><th>ID курса</th><th>Название курса</th><th>Описание</th><th>Преподаватель</th><th>Дата начала</th><th>Дата окончания</th><th>Телефон преподавателя</th></tr></thead><tbody>";

            int i = 0;
            while (i < courses.Count)
            {
                var course = courses[i];
                html += $"<tr><td>{course.CourseId}</td><td>{course.CourseName}</td><td>{course.Description}</td><td>{course.Teacher}</td><td>{course.StartDate.ToShortDateString()}</td><td>{course.EndDate.ToShortDateString()}</td><td>{course.TeacherPhone}</td></tr>";
                i++;
            }

            html += "</tbody></table>";
            return new HtmlString(html);
        }

        public static List<DatabaseCourseModel> GetMockDatabaseCourseList()
        {
            var courses = new List<DatabaseCourseModel>
            {
                new DatabaseCourseModel
                {
                    CourseId = 1,
                    CourseName = "Введение в базы данных",
                    Description = "Основы проектирования и работы с базами данных",
                    Teacher = "Родионов В.В.",
                    StartDate = new DateTime(2025, 1, 1),
                    EndDate = new DateTime(2025, 12, 31),
                    TeacherPhone = "+7 (999) 420-13-37"
                },
                new DatabaseCourseModel
                {
                    CourseId = 2,
                    CourseName = "Продвинутые базы данных",
                    Description = "Изучение NoSQL, оптимизация запросов и администрирование",
                    Teacher = "Петрова Е.С.",
                    StartDate = new DateTime(2024, 10, 15),
                    EndDate = new DateTime(2025, 3, 15),
                    TeacherPhone = "+7 (999) 234-56-78"
                },
                new DatabaseCourseModel
                {
                    CourseId = 3,
                    CourseName = "SQL для аналитиков",
                    Description = "Использование SQL для анализа данных и построения отчетов",
                    Teacher = "Сидоров Д.В.",
                    StartDate = new DateTime(2024, 11, 1),
                    EndDate = new DateTime(2025, 2, 28),
                    TeacherPhone = "+7 (999) 345-67-89"
                },
                new DatabaseCourseModel
                {
                    CourseId = 4,
                    CourseName = "Базы данных в облаке",
                    Description = "Работа с облачными базами данных: Yandex Cloud, Mail Cloud",
                    Teacher = "Козлов М.И.",
                    StartDate = new DateTime(2025, 1, 10),
                    EndDate = new DateTime(2025, 6, 10),
                    TeacherPhone = "+7 (999) 456-78-90"
                },
                new DatabaseCourseModel
                {
                    CourseId = 5,
                    CourseName = "Базы данных и Big Data",
                    Description = "Интеграция баз данных с Big Data технологиями: Hadoop, Spark",
                    Teacher = "Николаева О.Л.",
                    StartDate = new DateTime(2025, 3, 1),
                    EndDate = new DateTime(2025, 8, 31),
                    TeacherPhone = "+7 (999) 567-89-01"
                }
            };
            return courses;
        }
    }
}
