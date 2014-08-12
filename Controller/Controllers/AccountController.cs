namespace Controller.Controllers
{
    using Controller.Filters;
    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Responses;
    using Infrastructure.Tools;
    using Service.Account.Requests;
    using Service.Services;
    using Service.ViewModels.Account;
    using System.Web.Mvc;
    using WebMatrix.WebData;

    /// <summary>
    /// Account controller
    /// </summary>
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : ViewControllerBase
    {
        [AllowAnonymous]
        public ActionResult SetCulture(string returnUrl, string culture)
        {
            Cookies.SetCulture(HttpContext, culture);

            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult ValidateRegistration(RegistrationViewModel registrationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration");
            }

            var accountService = new AccountService();
            var request = new RegisterUserRequest(registrationViewModel);
            Response<Empty> response = accountService.RegisterUser(request);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View("Registration");
            }

            return RedirectToAction("Index", "Application");
        }

        [AllowAnonymous]
        public ActionResult ValidateLogin(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            var accountService = new AccountService();
            var request = new LoginUserRequest(loginViewModel);
            Response<Empty> response = accountService.LoginUser(request);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View("Login");
            }

            return RedirectToAction("Index", "Application");
        }
    }
}