using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exam_Program.Models
{
    public class Student
    {
        [Key]
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Fin { get; set; }
        public int StudentNumber { get; set; }
        public int Class { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
