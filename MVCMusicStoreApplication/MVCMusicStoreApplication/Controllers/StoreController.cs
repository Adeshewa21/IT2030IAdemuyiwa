﻿/*
using MVCMusicStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        MVCMusicStoreApplicationDB db = new MVCMusicStoreApplicationDB();

        // GET: Store
        //Browse by Genre
        [HttpGet]
        public ActionResult Browse()
        {
            return View(db.Genres.ToList());
        }

        // GET: Store
        [HttpGet]
        public ActionResult Index(int id)
        {
            var albumList = db.Albums.Where(a => a.GenreId == id).ToList();

            return View(albumList);
        }

        // GET: Store
        [HttpGet]
        public ActionResult Details(int? id)
        {
            Album album = db.Albums.Single(a => a.AlbumId == id);
            return View(album);
        }
    }
}

*/














using MVCMusicStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        MVCMusicStoreApplicationDB db = new MVCMusicStoreApplicationDB();

        // GET: Store
        //Browse by Genre
        [HttpGet]
        public ActionResult Browse()
        {
            var list = db.Genres.ToList();

            return View(list);            
        }

        // GET: Store
        [HttpGet]
        public ActionResult Index(int id)
        {
            var list = db.Albums.ToList();

            return View(list);
        }     

        // GET: Store
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }
    }
}

