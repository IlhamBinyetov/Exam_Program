using Exam_Program.Models;

namespace Exam_Program.ViewModels
{
    public class LessonViewModel
    {
        public string? Code { get; set; }
        public string? LessonName { get; set; }
        public int Class { get; set; }

        public List<Exam>? Exams { get; set; }

        public string? TeacherName { get; set; }
        public string? TeacherSurname { get; set; }
        public IList<Lesson>? Lessons { get; set; }

    }
}
