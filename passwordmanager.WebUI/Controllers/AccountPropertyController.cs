using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using passwordmanager.Business.Abstract;
using passwordmanager.Entities.Concrete;
using passwordmanager.WebUI.CustomPassword;
using passwordmanager.WebUI.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace passwordmanager.WebUI.Controllers
{
    public class AccountPropertyController : Controller
    {
        IAccountPropertyService _accountPropertyService;
        IPlatformService _platformService;
        ISafeService _safeService;
        ISystemTypeService _systemTypeService;
        IMapper _mapper;

        public string hash = "passwordmanager";

        public AccountPropertyController(IAccountPropertyService accountPropertyService, IPlatformService platformService, ISafeService safeService, ISystemTypeService systemTypeService, IMapper mapper)
        {
            _accountPropertyService = accountPropertyService;
            _platformService = platformService;
            _safeService = safeService;
            _systemTypeService = systemTypeService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var accountPropertyListModel = new AccountPropertyListModel()
            {
                AccountProperties = _accountPropertyService.GetAll(),
            };
            return View(accountPropertyListModel);
        }

        public IActionResult Create()
        {
            ViewBag.SystemTypeId = _systemTypeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            ViewBag.SafeId = _safeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            ViewBag.PlatformId = _platformService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(AccountPropertyModel accountPropertyModel)
        {
            ViewBag.SystemTypeId = _systemTypeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            ViewBag.SafeId = _safeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            ViewBag.PlatformId = _platformService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            if (ModelState.IsValid)
            {
                accountPropertyModel.CreateDate = DateTime.Now;
                accountPropertyModel.UpdateDate = DateTime.Now;
                accountPropertyModel.Password = Encrypt(accountPropertyModel.RePassword);
                accountPropertyModel.ModifyBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                accountPropertyModel.CreateBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                accountPropertyModel.AccountName = _systemTypeService.GetById(accountPropertyModel.SystemTypeId).Name + " - " + _platformService.GetById(accountPropertyModel.PlatformId).Name + " - " + _safeService.GetById(accountPropertyModel.SafeId).Name;
                AccountProperty accountProperty = _mapper.Map<AccountProperty>(accountPropertyModel);
                _accountPropertyService.Add(accountProperty);
                return RedirectToAction("Index", "AccountProperty");
            }
            return View(accountPropertyModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.SystemTypeId = _systemTypeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            ViewBag.SafeId = _safeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            ViewBag.PlatformId = _platformService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            var accountProperty = _accountPropertyService.GetById(id);
            AccountPropertyModel accountPropertyModel = _mapper.Map<AccountPropertyModel>(accountProperty);

            return View(accountPropertyModel);
        }
        [HttpPost]
        public IActionResult Edit(AccountPropertyModel accountPropertyModel)
        {
            ViewBag.SystemTypeId = _systemTypeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            ViewBag.SafeId = _safeService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            ViewBag.PlatformId = _platformService.GetAll().Where(a => a.Status == true).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            var getAccountProperty = _accountPropertyService.GetById(accountPropertyModel.Id);

            if (ModelState.IsValid)
            {
                accountPropertyModel.CreateDate = getAccountProperty.CreateDate;
                accountPropertyModel.UpdateDate = DateTime.Now;
                accountPropertyModel.ModifyBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                accountPropertyModel.CreateBy = getAccountProperty.CreateBy;
                accountPropertyModel.Password = getAccountProperty.Password;
                accountPropertyModel.AccountName = _systemTypeService.GetById(accountPropertyModel.SystemTypeId).Name + " - " + _platformService.GetById(accountPropertyModel.PlatformId).Name + " - " + _safeService.GetById(accountPropertyModel.SafeId).Name;
                AccountProperty accountProperty = _mapper.Map<AccountProperty>(accountPropertyModel);
                _accountPropertyService.Update(accountProperty);
                return RedirectToAction("Index", "AccountProperty");
            }
            return View(accountPropertyModel);
        }

        [HttpPost]
        public ActionResult StatusChange(int id, bool status)
        {
            var entity = _accountPropertyService.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Status = status;
            _accountPropertyService.Update(entity);
            return Json(new { result = 1, message = "Başarılı." });
        }
        [Obsolete]
        public ActionResult Modal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var accountProperty = _accountPropertyService.GetById((int)id);

            AccountPropertyModel accountPropertyModel = new AccountPropertyModel();
            accountPropertyModel.Password = Decrypt(accountProperty.Password);
            accountPropertyModel.UserName = accountProperty.UserName;
            return PartialView(accountPropertyModel);
        }

        public JsonResult GetPlatforms(int id)
        {
            var platforms = (from a in _systemTypeService.GetAll()
                          join b in _platformService.GetAll()
                          on a.Id equals b.SystemTypeId
                          where b.SystemTypeId == id
                          select new
                          {
                              Text = b.Name,
                              Value = b.Id.ToString()
                          }).ToList();
            return Json(platforms);
        }

        #region Encrypt&Decrypt

        [Obsolete]
        public string Encrypt(string sifre)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifre);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        [Obsolete]
        public string Decrypt(string SifrelenmisDeger)
        {
            byte[] data = Convert.FromBase64String(SifrelenmisDeger);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
        #endregion

        #region PasswordGenerate
        public string Generate(
            int requiredLength = 8,
            int requiredUniqueChars = 4,
            bool requireDigit = true,
            bool requireLowercase = true,
            bool requireNonAlphanumeric = true,
            bool requireUppercase = true)
        {
            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
            };
            CryptoRandom rand = new CryptoRandom();
            List<char> chars = new List<char>();

            if (requireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (requireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (requireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (requireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < requiredLength
                || chars.Distinct().Count() < requiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }
            return new string(chars.ToArray());
        }
        #endregion

        public JsonResult PasswordGenerate()
        {
            var password = Generate();
            return Json(password);
        }
    }
}
