namespace Controller.ViewControllers
{
    using System.Web.Mvc;
    using Infrastructure.BaseClasses;

    /// <summary>
    /// Application controller
    /// </summary>
    public class ApplicationController : ViewControllerBase
    {
        public ActionResult Index()
        {
            return View();
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