namespace Controller.Controllers
{
    using Infrastructure.BaseClasses;
    using System.Web.Mvc;
    using WebMatrix.WebData;

    /// <summary>
    /// Application controller
    /// </summary>
    [Authorize]
    public class ApplicationController : ViewControllerBase
    {
        // GET: /Application
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (WebSecurity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: /Application/AboutContent
        public ActionResult AboutContent()
        {
            return PartialView("Content/_About");
        }

        // GET: /Application/ChatRoomsContent
        public ActionResult ChatRoomsContent()
        {
            return PartialView("Content/_ChatRooms");
        }

        // GET: /Application/HomeContent
        public ActionResult HomeContent()
        {
            return PartialView("Content/_Home");
        }

        // GET: /Application/SettingsContent
        public ActionResult SettingsContent()
        {
            return PartialView("Content/_Settings");
        }

        // GET: /Application/UsersContent
        public ActionResult UsersContent()
        {
            return PartialView("Content/_Users");
        }
    }
}