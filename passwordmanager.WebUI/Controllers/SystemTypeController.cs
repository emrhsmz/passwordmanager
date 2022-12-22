using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using passwordmanager.Business.Abstract;
using passwordmanager.Entities.Concrete;
using passwordmanager.WebUI.Models;
using System.Security.Claims;

namespace passwordmanager.WebUI.Controllers
{
    public class SystemTypeController : Controller
    {
        ISystemTypeService _systemTypeService;
        IMapper _mapper;

        public SystemTypeController(ISystemTypeService systemTypeService, IMapper mapper)
        {
            _systemTypeService = systemTypeService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var systemTypeList = new SystemTypeListModel()
            {
                SystemTypes = _systemTypeService.GetAll().OrderByDescending(a => a.Id).ToList(),
            };
            return View(systemTypeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SystemTypeModel systemTypeModel)
        {
            if (ModelState.IsValid)
            {
                systemTypeModel.CreateDate = DateTime.Now;
                systemTypeModel.UpdateDate = DateTime.Now;
                SystemType systemType = _mapper.Map<SystemType>(systemTypeModel);
                _systemTypeService.Add(systemType);
                ViewBag.Info = "Başarıyla Eklendi";
                return RedirectToAction("Index", "SystemType");
            }
            return View(systemTypeModel);
        }

        public IActionResult Edit(int id)
        {
            var systemType = _systemTypeService.GetById(id);
            SystemTypeModel systemTypeModel = _mapper.Map<SystemTypeModel>(systemType);

            return View(systemTypeModel);
        }
        [HttpPost]
        public IActionResult Edit(SystemTypeModel systemTypeModel)
        {
            var getSystemType = _systemTypeService.GetById(systemTypeModel.Id);

            if (ModelState.IsValid)
            {
                systemTypeModel.CreateDate = getSystemType.CreateDate;
                systemTypeModel.UpdateDate = DateTime.Now;
                SystemType systemType = _mapper.Map<SystemType>(systemTypeModel);
                _systemTypeService.Update(systemType);
                return RedirectToAction("Index", "SystemType");
            }
            return View(systemTypeModel);
        }

        [HttpPost]
        public ActionResult StatusChange(int id, bool status)
        {
            var entity = _systemTypeService.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Status = status;
            _systemTypeService.Update(entity);
            return Json(new { result = 1, message = "Başarılı." });
        }
    }
}
