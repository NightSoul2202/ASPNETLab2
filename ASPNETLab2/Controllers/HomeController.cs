using ASPNETLab2.Models;
using ASPNETLab2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETLab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly CompanyService _companyService;
        private readonly AboutMeService _aboutMeService;

        public HomeController(ILogger<HomeController> logger, /*CompanyService companyService,*/ AboutMeService aboutMeService)
        {
            _logger = logger;
            //_companyService = companyService;
            _aboutMeService = aboutMeService;   
        }


        public IActionResult Index()
        {
            //var company = _companyService.GetCompanyWithMostEmployees();
            //return View(company);

            var aboutMe = _aboutMeService.GetUserInfo();
            return View(aboutMe);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
