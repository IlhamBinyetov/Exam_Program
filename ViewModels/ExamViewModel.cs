using Exam_Program.Models;

namespace Exam_Program.ViewModels
{
    public class ExamViewModel
    {
        public DateTime? ExamDate { get; set; }
        public double Score { get; set; }
        public char LessonCode { get; set; }
        public int StudentNumber { get; set; }
        public IList<Exam> Exams { get; set; }
    }
}
