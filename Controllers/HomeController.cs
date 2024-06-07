using Exam_Program.Models;
using Exam_Program.Services;
using Exam_Program.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam_Program.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGeneralService _generalService;


        public HomeController(ILogger<HomeController> logger, IGeneralService generalService)
        {
            _logger = logger;
            _generalService = generalService;
        }

        public IActionResult Index()
        {
            return View();
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
            //success = _generalService;

            return View();
        }



    }
}
