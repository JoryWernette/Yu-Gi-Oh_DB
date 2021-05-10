/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
///     
/// The controller for the
/// Card action methods.
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresentation.Controllers
{
    /// <summary>
    /// Jory A. Wernette
    /// Created: 2021/05/10
    ///
    /// Shows a user a page of useful duel tools
    /// </summary>
    public class ToolsController : Controller
    {
        // GET: Tools
        public ActionResult Tools()
        {
            return View();
        }
    }
}