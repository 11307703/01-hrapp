using HrApp.Services.Interfaces;
using HrApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly IIdentityService _service;

        public AccountController(IIdentityService service)
        {
          _service = service;
        }

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        #region Login Username

        [HttpGet]
        public IActionResult LoginUserName()
        {
            return View();
        }

        //TODO
        [HttpPost]
        public async Task<IActionResult> LoginUserName(LoginUserNameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.LoginAsync("", model.UserName, model.Password);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.ErrorString);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        #endregion

        #region Login Email

        [HttpGet]
        public IActionResult LoginEmail()
        {
            return View();
        }

        //TODO
        [HttpPost]
        public async Task<IActionResult> LoginEmail(LoginEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.LoginAsync("", model.Email, model.Password);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.ErrorString);
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
            return View(model);
        }
        #endregion

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.RegisterAsync(registerModel);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.ErrorString);
                }
                else
                {
                    return View("Login");
                }
            }
            return View();
        }

        #endregion

        #region Logout

        public async Task<IActionResult> LogoutAsync()
        {
            await _service.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #endregion
    }
}
