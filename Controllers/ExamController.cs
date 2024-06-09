using Exam_Program.Models;
using Exam_Program.Services;
using Exam_Program.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Program.Controllers
{
    public class ExamController : Controller
    {
        private readonly IGeneralService _generalService;

        public ExamController(IGeneralService generalService)
        {
                _generalService = generalService;
        }
        public IActionResult Index(ExamViewModel viewModel)
        {
            viewModel ??= new ExamViewModel();

            IList<Exam> exams = _generalService.GetAllExams();

            viewModel.Exams = exams;

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult CreateExam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExam(ExamViewModel model)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                success = _generalService.AddExam(model);
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
        public IActionResult Details(ExamViewModel viewModel)
        {
            return RedirectToAction("Index", "Exam");
        }
    }
}
