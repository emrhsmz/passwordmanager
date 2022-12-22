using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using passwordmanager.Business.Abstract;
using passwordmanager.Entities.Concrete;
using passwordmanager.WebUI.Models;
using System.Security.Claims;

namespace passwordmanager.WebUI.Controllers
{
    public class PlatformController : Controller
    {
        IPlatformService _platformService;
        ISystemTypeService _systemTypeService;
        IMapper _mapper;

        public PlatformController(IPlatformService platformService, ISystemTypeService systemTypeService, IMapper mapper)
        {
            _platformService = platformService;
            _systemTypeService = systemTypeService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var platformList = new PlatformListModel()
            {
                Platforms = _platformService.GetWithAnotherTable().OrderByDescending(a => a.Id).ToList(),
            };
            return View(platformList);
        }

        public IActionResult Create()
        {
            ViewBag.SystemTypeId = _systemTypeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public IActionResult Create(PlatformModel platformModel)
        {
            ViewBag.SystemTypeId = _systemTypeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            if (ModelState.IsValid)
            {
                platformModel.CreateDate = DateTime.Now;
                platformModel.UpdateDate = DateTime.Now;
                Platform platform = _mapper.Map<Platform>(platformModel);
                _platformService.Add(platform);
                ViewBag.Info = "Başarıyla Eklendi";
                return RedirectToAction("Index", "Platform");
            }
            return View(platformModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.SystemTypeId = _systemTypeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            var platform = _platformService.GetById(id);
            PlatformModel platformModel = _mapper.Map<PlatformModel>(platform);

            return View(platformModel);
        }
        [HttpPost]
        public IActionResult Edit(PlatformModel platformModel)
        {
            ViewBag.SystemTypeId = _systemTypeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            var getCategory = _platformService.GetById(platformModel.Id);

            if (ModelState.IsValid)
            {
                platformModel.CreateDate = getCategory.CreateDate;
                platformModel.UpdateDate = DateTime.Now;
                Platform platform = _mapper.Map<Platform>(platformModel);
                _platformService.Update(platform);
                return RedirectToAction("Index", "Platform");
            }
            return View(platformModel);
        }

        [HttpPost]
        public ActionResult StatusChange(int id, bool status)
        {
            var entity = _platformService.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Status = status;
            _platformService.Update(entity);
            return Json(new { result = 1, message = "Başarılı." });
        }
    }
}
