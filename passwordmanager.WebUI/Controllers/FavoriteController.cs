using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using passwordmanager.Business.Abstract;
using passwordmanager.Entities.Concrete;
using passwordmanager.WebUI.Models;
using System.Security.Claims;

namespace passwordmanager.WebUI.Controllers
{
    public class FavoriteController : Controller
    {
        IFavoriteService _favoriteService;
        IAccountPropertyService _accountPropertyService;
        IMapper _mapper;

        public FavoriteController(IFavoriteService favoriteService, IAccountPropertyService accountPropertyService, IMapper mapper)
        {
            _favoriteService = favoriteService;
            _accountPropertyService = accountPropertyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var favoriteList = new FavoriteListModel()
            {
                Favorites = _favoriteService.GetAll().OrderByDescending(a => a.Id).ToList(),
            };
            return View(favoriteList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FavoriteModel favoriteModel)
        {
            if (ModelState.IsValid)
            {
                favoriteModel.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Favorite favorite = _mapper.Map<Favorite>(favoriteModel);
                _favoriteService.Add(favorite);
                ViewBag.Info = "Başarıyla Eklendi";
                return RedirectToAction("Index", "Favorite");
            }
            return View(favoriteModel);
        }

        public IActionResult Edit(int id)
        {
            var favorite = _favoriteService.GetById(id);
            FavoriteModel favoriteModel = _mapper.Map<FavoriteModel>(favorite);

            return View(favoriteModel);
        }
        [HttpPost]
        public IActionResult Edit(FavoriteModel favoriteModel)
        {
            var getFavorite = _favoriteService.GetById(favoriteModel.Id);

            if (ModelState.IsValid)
            {
                favoriteModel.UserId = getFavorite.UserId;
                Favorite favorite = _mapper.Map<Favorite>(favoriteModel);
                _favoriteService.Update(favorite);
                return RedirectToAction("Index", "Favorite");
            }
            return View(favoriteModel);
        }

        [HttpPost]
        public ActionResult AddRemoveFavorite(int id)
        {
            var entity = _favoriteService.GetByAccountProprtyId(id);
            var account = _accountPropertyService.GetById(id);

            if (entity == null)
            {
                Favorite favorite = new Favorite();
                favorite.AccountPropertyId = id;
                favorite.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _favoriteService.Add(favorite);

                account.isFavorite = true;
                _accountPropertyService.Update(account);

            }
            else
            {
                _favoriteService.Delete(entity);
                account.isFavorite = false;
                _accountPropertyService.Update(account);
            }
            return Json(new { result = 1, message = "Başarılı." });
        }
    }
}
