using Exam_Program.Data;
using Exam_Program.Models;
using Exam_Program.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Exam_Program.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly EduDbContext _dbContext;
        public GeneralService(EduDbContext dbContext)
        {
                _dbContext = dbContext;
        }
        public bool AddExam(ExamViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException();
            try
            {
                Exam exam = new Exam()
                {
                    
                    StudentNumber = viewModel.StudentNumber,
                    ExamDate = viewModel.ExamDate,
                    Score = viewModel.Score,
                    LessonCode = viewModel.LessonCode
                };
                _dbContext.Exams.Add(exam);
                _dbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public bool AddLesson(LessonViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException();
            try
            {
                Lesson lesson = new Lesson()
                {
                    Code = GenerateUniqueLessonCode(),
                    Class = viewModel.Class,
                    Name = viewModel.LessonName,
                    TeacherName = viewModel.TeacherName,
                    TeacherSurname = viewModel.TeacherSurname
                };
                _dbContext.Lessons.Add(lesson);
                _dbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
       
            return true;
        }

        public bool AddStudent(StudentViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException();
            try
            {
                Student student = new Student()
                {
                    StudentNumber = viewModel.StudentNumber,
                    Class = viewModel.Class,
                    Name = viewModel.Name,
                    Surname = viewModel.Surname
                };
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        
        IList<Exam> IGeneralService.GetAllExams()
        {
            return _dbContext.Exams.ToList();
        }

        IList<Lesson> IGeneralService.GetAllLesson()
        {
            return _dbContext.Lessons.ToList();
        }

        IList<Student> IGeneralService.GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }


        public string GenerateUniqueLessonCode()
        {
            var existingCodes = _dbContext.Lessons.Select(l => l.Code.ToString()).ToList();
            for (char c1 = 'A'; c1 <= 'Z'; c1++)
            {
                for (char c2 = 'A'; c2 <= 'Z'; c2++)
                {
                    for (char c3 = 'A'; c3 <= 'Z'; c3++)
                    {
                        string code = $"{c1}{c2}{c3}";
                        if (!existingCodes.Contains(code))
                        {
                            return code;
                        }
                    }
                }
            }
            throw new Exception("Benzersiz ders kodu kalmadı");
        }
    }


    public interface IGeneralService
    {
        IList<Lesson> GetAllLesson();
        IList<Exam> GetAllExams();
        IList<Student> GetAllStudents();
        bool AddLesson(LessonViewModel viewModel);
        bool AddStudent(StudentViewModel viewModel);
        bool AddExam(ExamViewModel viewModel);
        string GenerateUniqueLessonCode();
    }

}
