using ASPProject4.Models;
using ASPProject4.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace ASPProject4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileAdapter _fileAdapter;
// injecting fileAdapter class for evaluating the type of class uploaded 
        public HomeController(ILogger<HomeController> logger, IFileAdapter fileAdapter)
        {
            _logger = logger;
            _fileAdapter = fileAdapter;
        }
// handles the get request
        [HttpGet]
        public IActionResult Index()
        {
            return View(new List<UserModel>());
        }

// Handles the post request submitted by the form
        [HttpPost]
        public IActionResult Index(IFormFile firmFile, IFormFile assetFile)
        {
            if (firmFile == null || assetFile == null)
            {
                return View(new List<UserModel>());
            }

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //  getting the services based on the type of file uploaded
            var service = _fileAdapter.GetService(firmFile);
            
            return View(service?.ParseFile(firmFile, assetFile));
        }
// About page
        public IActionResult About()
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