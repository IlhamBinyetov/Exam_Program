using Exam_Program.Models;
using Exam_Program.Services;
using Exam_Program.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Program.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGeneralService _generalService;

        public StudentController(IGeneralService generalService)
        {
            _generalService = generalService;
        }
        public IActionResult Index(StudentViewModel viewModel)
        {
            viewModel ??= new StudentViewModel();

            IList<Student> students = _generalService.GetAllStudents();

            viewModel.Students = students;

            return View(viewModel);
            
        }


        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentViewModel model)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                success = _generalService.AddStudent(model);
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
        public IActionResult Details(StudentViewModel viewModel)
        {
            return RedirectToAction("Index", "Student");
        }
    }
}
