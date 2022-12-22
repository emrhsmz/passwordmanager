using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using passwordmanager.Business.Abstract;
using passwordmanager.WebUI.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace passwordmanager.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IAccountPropertyService _accountPropertyService;
        public HomeController(ILogger<HomeController> logger, IAccountPropertyService accountPropertyService)
        {
            _logger = logger;
            _accountPropertyService = accountPropertyService;
        }

        public IActionResult Index(string filter)
        {
            //var accountPropertyListModel = new AccountPropertyListModel()
            //{
            //    AccountProperties = _accountPropertyService.GetAnotherTable().Where(a => a.CreateBy == User.FindFirst(ClaimTypes.NameIdentifier).Value).OrderByDescending(a => a.Id).ToList(),
            //};

            if (filter == "favorite")
            {
                var accountPropertyListModel = new AccountPropertyListModel()
                {
                    AccountProperties = _accountPropertyService.GetAnotherTable().Where(a => a.CreateBy == User.FindFirst(ClaimTypes.NameIdentifier).Value && a.isFavorite == true).OrderByDescending(a => a.Id).ToList(),
                };
                return View(accountPropertyListModel);
            }
            if (filter == "passive")
            {
                var accountPropertyListModel = new AccountPropertyListModel()
                {
                    AccountProperties = _accountPropertyService.GetAnotherTable().Where(a => a.CreateBy == User.FindFirst(ClaimTypes.NameIdentifier).Value && a.Status == false).OrderByDescending(a => a.Id).ToList(),
                };
                return View(accountPropertyListModel);
            }

            if (filter == null)
            {
                var accountPropertyListModel = new AccountPropertyListModel()
                {
                    AccountProperties = _accountPropertyService.GetAnotherTable().Where(a => a.CreateBy == User.FindFirst(ClaimTypes.NameIdentifier).Value).OrderByDescending(a => a.Id).ToList(),
                };
                return View(accountPropertyListModel);
            }
            return View();
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