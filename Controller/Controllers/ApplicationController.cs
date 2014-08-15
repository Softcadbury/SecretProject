namespace Controller.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.BaseClasses;

    using WebMatrix.WebData;

    /// <summary>
    /// Application controller
    /// </summary>
    [Authorize]
    public class ApplicationController : ViewControllerBase
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (WebSecurity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AboutContent()
        {
            return PartialView("Content/_About");
        }

        public ActionResult ChatRoomsContent()
        {
            return PartialView("Content/_ChatRooms");
        }

        public ActionResult HomeContent()
        {
            return PartialView("Content/_Home");
        }

        public ActionResult SettingsContent()
        {
            return PartialView("Content/_Settings");
        }

        public ActionResult UsersContent()
        {
            return PartialView("Content/_Users");
        }
    }
}