﻿namespace Controller.Controllers.View
{
    using Controller.Filters;
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Infrastructure.Tools;
    using Service.Services;
    using Service.ViewModels.Account;
    using System.Web.Mvc;
    using WebMatrix.WebData;

    /// <summary>
    /// Account controller
    /// </summary>
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : ControllerViewBase
    {
        // GET: /Account/SetCulture
        [AllowAnonymous]
        public ActionResult SetCulture(string returnUrl, string culture)
        {
            Cookies.SetCulture(HttpContext, culture);

            return Redirect(returnUrl);
        }

        // GET: /Account/Registration
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/ValidateRegistration
        [AllowAnonymous]
        public ActionResult ValidateRegistration(RegistrationViewModel registrationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration");
            }

            var accountService = new AccountService();
            Response<Empty> response = accountService.RegisterUser(registrationViewModel);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View("Registration");
            }

            return RedirectToAction("Index", "Application");
        }

        // GET: /Account/ValidateLogin
        [AllowAnonymous]
        public ActionResult ValidateLogin(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            var accountService = new AccountService();
            Response<Empty> response = accountService.LoginUser(loginViewModel);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View("Login");
            }

            return RedirectToAction("Index", "Application");
        }
    }
}