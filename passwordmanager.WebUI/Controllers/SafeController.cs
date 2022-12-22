using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using passwordmanager.Business.Abstract;
using passwordmanager.Entities.Concrete;
using passwordmanager.WebUI.Models;

namespace passwordmanager.WebUI.Controllers
{
    public class SafeController : Controller
    {
        ISafeService _safeService;
        IMapper _mapper;

        public SafeController(ISafeService safeService, IMapper mapper)
        {
            _safeService = safeService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var safeList = new SafeListModel()
            {
                Safes = _safeService.GetAll().OrderByDescending(a => a.Id).ToList(),
            };
            return View(safeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SafeModel safeModel)
        {
            if (ModelState.IsValid)
            {
                safeModel.CreateDate = DateTime.Now;
                safeModel.UpdateDate = DateTime.Now;
                Safe safe = _mapper.Map<Safe>(safeModel);
                _safeService.Add(safe);
                ViewBag.Info = "Başarıyla Eklendi";
                return RedirectToAction("Index", "Safe");
            }
            return View(safeModel);
        }

        public IActionResult Edit(int id)
        {
            var safe = _safeService.GetById(id);
            SafeModel safeModel = _mapper.Map<SafeModel>(safe);

            return View(safeModel);
        }
        [HttpPost]
        public IActionResult Edit(SafeModel safeModel)
        {
            var getSafe = _safeService.GetById(safeModel.Id);

            if (ModelState.IsValid)
            {
                safeModel.CreateDate = getSafe.CreateDate;
                safeModel.UpdateDate = DateTime.Now;
                Safe safe = _mapper.Map<Safe>(safeModel);
                _safeService.Update(safe);
                return RedirectToAction("Index", "Safe");
            }
            return View(safeModel);
        }

        [HttpPost]
        public ActionResult StatusChange(int id, bool status)
        {
            var entity = _safeService.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Status = status;
            _safeService.Update(entity);
            return Json(new { result = 1, message = "Başarılı." });
        }
    }
}
