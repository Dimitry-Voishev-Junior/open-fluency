using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenFluency.Web.Models;

namespace OpenFluency.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
