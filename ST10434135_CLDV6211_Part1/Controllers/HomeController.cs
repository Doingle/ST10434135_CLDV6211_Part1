using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ST10434135_CLDV6211_Part1.Models;

namespace ST10434135_CLDV6211_Part1.Controllers;

public class HomeController : Controller
{
    // this variable is used to log information to the console
    private readonly ILogger<HomeController> _logger;

    // this constructor initializes the logger
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //---------------------------------------------------------------------------------//
    // this IActionResult returns the index view
    public IActionResult Index()
    {
        return View();
    }

    //---------------------------------------------------------------------------------//
    // this IActionResult returns the privacy view
    public IActionResult Privacy()
    {
        return View();
    }

    //---------------------------------------------------------------------------------//
    // this IActionResult returns the error view
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
//---------------------------------------------------------EOF---------------------------------------------------------//
