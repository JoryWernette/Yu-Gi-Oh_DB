/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
///     
/// The controller for the
/// Home action methods.
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresentation.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Shows the player the home page
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Shows the player the About page
        /// </summary>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Shows the player the Contact page
        /// </summary>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}