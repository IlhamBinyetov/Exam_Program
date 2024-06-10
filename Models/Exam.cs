using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exam_Program.Models
{
    public class Exam
    {
        [Key]
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? ExamDate { get; set; }
        public double Score { get; set; }
        public Lesson? Lesson { get; set; }
        [Required]
        [StringLength(3)]
        public string? LessonCode { get; set; }
 
        public Student? Student { get; set; }
        [Required]
        public int StudentNumber { get; set; }

    }
}
