using Exam_Program.Models;
using Exam_Program.Services;
using Exam_Program.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Program.Controllers
{
    public class LessonController : Controller
    {
        private readonly IGeneralService _generalService;

        public LessonController(IGeneralService generalService)
        {
                _generalService = generalService;
        }
        public IActionResult Index(LessonViewModel viewModel)
        {
            viewModel ??= new LessonViewModel();

            IList<Lesson> lessons = _generalService.GetAllLesson();

            viewModel.Lessons = lessons;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateLesson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLesson(LessonViewModel model)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                success = _generalService.AddLesson(model);
            }
            ViewData["success"] = success;

            return View();
        }


        [HttpGet] 
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Details(LessonViewModel viewModel)
        {
            return RedirectToAction("Index", "Lesson");
        }
    }
}
