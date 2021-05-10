using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresentation.Controllers
{
    public class PlayerController : Controller
    {
        PlayerManager playerManager = new PlayerManager();

        // GET: Player
        public ActionResult Index()
        {
            List<Player> PlayerList = new List<Player>();
            PlayerList = playerManager.RetrievePlayersByActive();

            return View(PlayerList);
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            Player player = new Player();
            player = playerManager.SelectPlayerByKonamiID(id);
            return View(player);
        }

        //// GET: Player/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Player/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Player/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Player/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Player/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Player/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
