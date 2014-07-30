﻿namespace Controller.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.BaseClasses;

    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}