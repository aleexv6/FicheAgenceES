using FicheAgenceES.Agences;
using FicheAgenceES.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FicheAgenceES.Controllers
{
    public class AgencesController : Controller

    {

        // GET: Agences
        public ActionResult Index(Models.Agences age)
        {
            if (ModelState.IsValid)
            {
                var Client = new MongoClient("mongodb://127.0.0.1:27017");
                var db = Client.GetDatabase("agences_gca");
                var collection = db.GetCollection<Models.Agences>("agences").Find(new BsonDocument()).ToList();
                return View(collection);
            }
            return View();
        }

        // GET: Agences/Details/5
        public ActionResult Details(string id)
        {
            if (ModelState.IsValid)
            {
                var Client = new MongoClient("mongodb://127.0.0.1:27017");
                var db = Client.GetDatabase("agences_gca");
                var filter = Builders<Models.Agences>.Filter.Eq("id", id);
                var collection = db.GetCollection<Models.Agences>("agences").Find(filter);
                return View(collection);
            }
            return View();
        }

        // GET: Agences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agences/Create
        [HttpPost]
        public ActionResult Create(Models.Agences agence)
        {
            if (ModelState.IsValid)
            {
                var Client = new MongoClient("mongodb://127.0.0.1:27017");
                var db = Client.GetDatabase("agences_gca");
                var collection = db.GetCollection<Models.Agences>("agences");
                collection.InsertOneAsync(agence);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Agences/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Agences/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Agences agence)
        {
            if (ModelState.IsValid)
            {
                var Client = new MongoClient("mongodb://127.0.0.1:27017");
                var db = Client.GetDatabase("agences_gca");
                var collection = db.GetCollection<Models.Agences>("agences");
                var update = collection.FindOneAndUpdateAsync(Builders<Models.Agences>.Filter.Eq("id", agence.id), 
                    Builders<Models.Agences>.Update.Set("nom", agence.nom).Set("tel", agence.tel));

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Agences/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Agences/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                var Client = new MongoClient("mongodb://127.0.0.1:27017");
                var db = Client.GetDatabase("agences_gca");
                var collection1 = db.GetCollection<Models.Agences>("agences");
                var delete = collection1.DeleteOneAsync(Builders<Models.Agences>.Filter.Eq("id", id));
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
