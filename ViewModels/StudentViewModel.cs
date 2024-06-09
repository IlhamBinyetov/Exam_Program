using Exam_Program.Models;

namespace Exam_Program.ViewModels
{
    public class StudentViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Fin { get; set; }
        public int StudentNumber { get; set; }
        public int Class { get; set; }
        public IList<Student>? Students { get; set; }
    }
}
