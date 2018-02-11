using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmmasBlogg.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmmasBlogg.Controllers
{
    public class HomeController : Controller
    {
     //   private readonly InläggsContext _context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult Kategorier()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Value = "1", Text = "Mat"});
            items.Add(new SelectListItem { Value = "2", Text = "Mode" });
            items.Add(new SelectListItem { Value = "3", Text = "Övrigt" });
            ViewBag.Kategori = items;

            return View();
        }

    }
}
