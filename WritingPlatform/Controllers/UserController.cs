using Models.Users;
using Service.Abstractions;
using System.Web.Mvc;
using System.Linq;
using System.Web.Security;
using Service;


namespace WritingPlatform.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(NewUserModel userModel)
        {
            var status = false;
            var message = "";
            if (ModelState.IsValid)
            {
                if (IsLoginExist(userModel.Login))
                {
                    ModelState.AddModelError("loginExist", "Пользователь с таким логином уже зарегистрирован");
                    return View(userModel);
                }
                if (IsEmailExist(userModel.Email))
                {
                    ModelState.AddModelError("emailExist", "Такой email уже зарегистрирован");
                    return View(userModel);
                }
                _userService.Create(userModel);
                FormsAuthentication.SetAuthCookie(userModel.Login, true);
                message = "Регистрация завершена успешно!";
                status = true;
            }
            else
            {
                message = "Ошибка!";
            }
            ViewBag.Message = message;
            ViewBag.Status = status;
            return View(userModel);
        }

        [HttpGet] 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel userModel, string returnUrl="")
        {
            string message = "";
            var user = _userService.GetAll()
                .Where(item => item.Login == userModel.Login)
                .FirstOrDefault();
            if (user != null && !user.IsDeleted)
            {
                if (Crypto.Hash(userModel.Password) == user.Password)
                {
                    FormsAuthentication.SetAuthCookie(userModel.Login, true);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    message = "Неверный пароль";
                }
            }
            else
            {
                message = "Пользователь с таким логином не зарегистрирован";
            }
            ViewBag.Message = message;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Settings()
        {
            var user = _userService.GetAll()
                .Where(item => item.Login == User.Identity.Name)
                .FirstOrDefault();
            user.Password = "";
            return View(user);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Settings(UserModel userModel)
        {
            var user = _userService.GetById(userModel.Id);
            user.Login = userModel.Login;
            user.Password = Crypto.Hash(userModel.Password);
            user.Email = userModel.Email;
            _userService.Update(user);
            user = _userService.GetById(userModel.Id);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [Authorize]
        public ActionResult Delete()
        {
            var user = _userService.GetAll()
                .Where(item => item.Login == User.Identity.Name)
                .FirstOrDefault();
            _userService.DeleteById(user.Id);
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool IsLoginExist(string login)
        {
            var result = _userService.GetAll().FirstOrDefault(user => user.Login == login);
            return result != null;
        }

        [NonAction]
        public bool IsEmailExist(string email)
        {
            var result = _userService.GetAll().FirstOrDefault(user => user.Email == email);
            return result != null;
        }
    }
}