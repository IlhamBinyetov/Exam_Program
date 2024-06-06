﻿namespace Exam_Program.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public DateTime? ExamDate { get; set; }
        public decimal Price { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }

    }
}
