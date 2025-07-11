using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FoolOfRESTWeb.Models;

namespace FoolOfRESTWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
