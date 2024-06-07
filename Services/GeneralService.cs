using Exam_Program.ViewModels;

namespace Exam_Program.Services
{
    public class GeneralService : IGeneralService
    {
        public bool AddExam(LessonViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public bool AddLesson(LessonViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public bool AddStudent(LessonViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }


    public interface IGeneralService
    {
        bool AddLesson(LessonViewModel viewModel);
        bool AddStudent(LessonViewModel viewModel);
        bool AddExam(LessonViewModel viewModel);
    }

}
