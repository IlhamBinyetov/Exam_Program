using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exam_Program.Models
{
    public class Lesson
    {
        [Key]
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public char Code { get; set; }
        public string? Name { get; set; }
        public int Class { get; set; }
        
        public List<Exam> Exams { get; set; }

       public string? TeacherName { get; set; } 
       public string? TeacherSurname { get; set; }

    }
}
